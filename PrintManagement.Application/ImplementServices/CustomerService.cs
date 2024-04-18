﻿using Microsoft.AspNetCore.Http;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Application.Payloads.RequestModels.CustomerRequests;
using PrintManagement.Application.Payloads.RequestModels.InputRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataCustomer;
using PrintManagement.Application.Payloads.Responses;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using PrintManagement.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.ImplementServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IBaseReposiroty<Customer> _baseCustomerRepository;
        private readonly IBaseReposiroty<User> _baseUserRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBaseReposiroty<Team> _baseTeamRepository;
        private readonly CustomerConverter _mapper;
        public CustomerService(IBaseReposiroty<Customer> baseCustomerRepository, IBaseReposiroty<User> baseUserRepository, IHttpContextAccessor httpContextAccessor, CustomerConverter mapper, IBaseReposiroty<Team> baseTeamRepository)
        {
            _baseCustomerRepository = baseCustomerRepository;
            _baseUserRepository = baseUserRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _baseTeamRepository = baseTeamRepository;
        }

        public async Task<ResponseObject<DataResponseCustomer>> CreateCustomer(Request_CreateCustomer request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                var user = await _baseUserRepository.GetAsync(x => x.Id == Guid.Parse(currentUser.FindFirst("Id").Value));
                var team = await _baseTeamRepository.GetAsync(x => x.Id == user.TeamId);
                if (!team.Name.Equals("Sales"))
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You must be an employee in the sales department",
                        Data = null
                    };
                }
                if(!ValidateInput.IsValidPhoneNumber(request.PhoneNumber))
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Invalid phone number format",
                        Data = null
                    };
                }
                if (!ValidateInput.IsValidEmail(request.Email))
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Invalid email format",
                        Data = null
                    };
                }
                var customerItem = await _baseCustomerRepository.GetAsync(x => x.PhoneNumber.Equals(request.PhoneNumber));
                if(customerItem != null)
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Phone number existed",
                        Data = null
                    };
                }
                
                Customer customer = new Customer
                {
                    Address = request.Address,
                    IsActive = true,
                    FullName = request.FullName,
                    Id = Guid.NewGuid(),
                    PhoneNumber = request.PhoneNumber
                };
                customer = await _baseCustomerRepository.CreateAsync(customer);
                return new ResponseObject<DataResponseCustomer>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Customer created successfully",
                    Data = _mapper.EntityToDTOForCustomer(customer)
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<DataResponseCustomer>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }

        public async Task<string> DeleteCustomer(Guid id)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                var customer = await _baseCustomerRepository.GetByIDAsync(id);
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return "UnAuthenticated user";
                }
                if (!currentUser.IsInRole("Admin"))
                {
                    return "You do not have permission to perform this function";
                }
                if(customer == null)
                {
                    return "Customer not found";
                }
                customer.IsActive = false;
                await _baseCustomerRepository.UpdateAsync(customer);
                return "Successfully deleted the customer";
            }catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public async Task<IQueryable<DataResponseCustomer>> GetAllCustomers(Request_InputCustomer request)
        {
            try
            {
                var query = await _baseCustomerRepository.GetAllAsync(x => x.IsActive == true);
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                {
                    query = query.Where(x => x.PhoneNumber.Contains(request.PhoneNumber));
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.FullName.ToLower().Contains(request.Name.ToLower()));
                }
                if (!string.IsNullOrEmpty(request.Address))
                {
                    query = query.Where(x => x.Address.ToLower().Contains(request.Address.ToLower()));
                }
                return query.Select(x => new DataResponseCustomer
                {
                    Address = x.Address,
                    FullName = x.FullName,
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber
                });
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message, nameof(request));
            }
        }

        public async Task<DataResponseCustomer> GetCustomerById(Guid id)
        {
            var customer = await _baseCustomerRepository.GetByIDAsync(id);
            return _mapper.EntityToDTOForCustomer(customer);
        }

        public async Task<ResponseObject<DataResponseCustomer>> UpdateCustomer(Request_UpdateCustomer request)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            try
            {
                if (!currentUser.Identity.IsAuthenticated)
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Message = "UnAuthenticated user",
                        Data = null
                    };
                }
                var user = await _baseUserRepository.GetAsync(x => x.Id == Guid.Parse(currentUser.FindFirst("Id").Value));
                var team = await _baseTeamRepository.GetAsync(x => x.Id == user.TeamId);
                if (!team.Name.Equals("Sales"))
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status403Forbidden,
                        Message = "You must be an employee in the sales department",
                        Data = null
                    };
                }
                if (!ValidateInput.IsValidPhoneNumber(request.PhoneNumber))
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Invalid phone number format",
                        Data = null
                    };
                }
                if (!ValidateInput.IsValidEmail(request.Email))
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Invalid email format",
                        Data = null
                    };
                }
                var customer = await _baseCustomerRepository.GetByIDAsync(request.Id);
                if(customer == null)
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status404NotFound, 
                        Message = "Customer not found",
                        Data = null
                    };
                }
                if(customer.IsActive == false)
                {
                    return new ResponseObject<DataResponseCustomer>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "This customer has been deleted",
                        Data = null
                    };
                }
                customer.Address = request.Address;
                customer.FullName = request.FullName;
                customer.PhoneNumber = request.PhoneNumber;
                await _baseCustomerRepository.UpdateAsync(customer);
                return new ResponseObject<DataResponseCustomer>
                {
                    Status = StatusCodes.Status200OK,
                    Message = "Successfully updated successfully",
                    Data= _mapper.EntityToDTOForCustomer(customer)
                };
            }catch(Exception ex)
            {
                return new ResponseObject<DataResponseCustomer>
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}
