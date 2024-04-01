﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.RequestModels.UserRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataLogin;
using PrintManagement.Application.Payloads.ResponseModels.DataUser;
using PrintManagement.Application.Payloads.Responses;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using PrintManagement.Domain.InterfaceRepositories.InterfaceUser;
using PrintManagement.Domain.Validations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BcryptNet = BCrypt.Net.BCrypt;

namespace PrintManagement.Application.ImplementServices
{
    public class AuthService : IAuthService
    {
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<User> _userRepository;
        private readonly IBaseReposiroty<RefreshToken> _baseRefreshTokenRepository;
        public AuthService(IBaseReposiroty<User> baseUserRepository, IMapper mapper, IConfiguration configuration, IUserRepository<User> userRepository, IBaseReposiroty<RefreshToken> baseRefreshTokenRepository)
        {
            _baseUserRepository = baseUserRepository;
            _mapper = mapper;
            _configuration = configuration;
            _userRepository = userRepository;
            _baseRefreshTokenRepository = baseRefreshTokenRepository;
        }
        public async Task<ResponseObject<DataResponseLogin>> GetJwtTokenAsync(User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("Email", user.Email),
                    new Claim("Avatar", user.Avatar),
                    new Claim("FullName", user.FullName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var userRoles = await _userRepository.GetRolesOfUserAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtToken = GetToken(authClaims); //access token
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken rf = new RefreshToken
            {
                UserId = user.Id,
                ExpiryTime = DateTime.Now.AddDays(refreshTokenValidity),
                Token = refreshToken
            };

            rf = await _baseRefreshTokenRepository.CreateAsync(rf);
            return new ResponseObject<DataResponseLogin>
            {
                Status = StatusCodes.Status200OK,
                Message = "Token created successfully",
                Data = new DataResponseLogin
                {
                    Id = rf.Id,
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    RefreshToken = refreshToken,
                    User = new DataResponseUser
                    {
                        CreateTime = user.CreateTime,
                        DateOfBirth = user.DateOfBirth,
                        Email = user.Email,
                        FullName = user.FullName,
                        Id = user.Id,
                        PhoneNumber = user.PhoneNumber,
                    }
                }
            };
            
        }
        public async Task<ResponseObject<DataResponseLogin>> Login(Request_Login request)
        {
            try
            {
                var user = await _userRepository.GetUserByUsername(request.Username);
                if (user == null)
                {
                    return new ResponseObject<DataResponseLogin>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Account doesn't exist",
                        Data = null
                    };
                }
                var checkPassword = BcryptNet.Verify(request.Password, user.Password);
                if (!checkPassword)
                {
                    return new ResponseObject<DataResponseLogin>
                    {
                        Status = StatusCodes.Status400BadRequest, 
                        Message = "Incorrect password",
                        Data = null
                    };
                }
                return new ResponseObject<DataResponseLogin>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Successful login",
                    Data = new DataResponseLogin
                    {
                        AccessToken = GetJwtTokenAsync(user).Result.Data.AccessToken,
                        Id = user.Id,
                        RefreshToken = GetJwtTokenAsync(user).Result.Data.RefreshToken,
                        User = new DataResponseUser
                        {
                            CreateTime = user.CreateTime,
                            DateOfBirth = user.DateOfBirth,
                            Email = user.Email,
                            FullName = user.FullName,
                            Id = user.Id,
                            PhoneNumber = user.PhoneNumber,
                        }
                    }
                };
            }catch (Exception ex)
            {
                return new ResponseObject<DataResponseLogin>
                {
                    Status =StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<ResponseObject<DataResponseUser>> Register(Request_Register request)
        {
            try
            {
                if(await _userRepository.GetUserByEmail(request.Email) != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Email already exists",
                        Data = null
                    };
                }
                if (await _userRepository.GetUserByPhoneNumber(request.PhoneNumber) != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Phone number already exists",
                        Data = null
                    };
                }
                if (await _userRepository.GetUserByUsername(request.Username) != null)
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Username already exists",
                        Data = null
                    };
                }
                if (!ValidateInput.IsValidEmail(request.Email))
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Invalid email format",
                        Data = null
                    };
                }
                if (!ValidateInput.IsValidPhoneNumber(request.PhoneNumber))
                {
                    return new ResponseObject<DataResponseUser>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Invalid phone number format",
                        Data = null
                    };
                }
                var user = new User
                {
                    Avatar = "https://scontent.xx.fbcdn.net/v/t1.15752-9/423737674_1480040725879365_4588731426501580823_n.png?stp=dst-png_s206x206&_nc_cat=101&ccb=1-7&_nc_sid=5f2048&_nc_eui2=AeGxnP82_YkVFLWwGazF7yI5KZjnfOEJczUpmOd84QlzNRfr9gdH6syoper3Yh0oOyo5y2ipmbd59Dwk6Ozyz536&_nc_ohc=eJwRiZR1zw0AX94Q9w9&_nc_ad=z-m&_nc_cid=0&_nc_ht=scontent.xx&oh=03_AdSAsCug3mmQNHjjqLBlE4vswrK6MxAOKWbXdPwaEh6CfA&oe=66109EB0",
                    IsActive = true,
                    CreateTime = DateTime.Now,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    FullName = request.FullName,
                    Id = Guid.NewGuid(),
                    Gender = request.Gender,
                    Password = BcryptNet.HashPassword(request.Password),
                    PhoneNumber = request.PhoneNumber,
                    UserName = request.Username
                };
                user = await _baseUserRepository.CreateAsync(user);
                await _userRepository.AddUserToRoleAsync(user, new List<string> { "Admin" });
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "User created successfully",
                    Data = new DataResponseUser
                    {
                        Id =user.Id,
                        CreateTime = user.CreateTime,
                        DateOfBirth = user.DateOfBirth,
                        Email = user.Email,
                        FullName = user.FullName,
                        PhoneNumber = user.PhoneNumber,
                    }
                };
            }
            catch(Exception ex)
            {
                return new ResponseObject<DataResponseUser>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Error: " + ex.Message,
                    Data = null
                };
            }
        }

        #region PrivateMethods
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);
            var expirationTimeUtc = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes);
            var localTimeZone = TimeZoneInfo.Local;
            var expirationTimeInLocalTimeZone = TimeZoneInfo.ConvertTimeFromUtc(expirationTimeUtc, localTimeZone);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: expirationTimeInLocalTimeZone,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new Byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetClaimsPrincipal(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out SecurityToken securityToken);

            return principal;

        }



        #endregion
    }
}
