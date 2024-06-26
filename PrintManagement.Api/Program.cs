﻿using Duende.IdentityServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PrintManagement.Api.Config.ServiceConverter;
using PrintManagement.Api.Config.ServiceOther;
using PrintManagement.Api.Config.ServiceRegister;
using PrintManagement.Api.MiddleWare;
using PrintManagement.Application.Constants;
using PrintManagement.Application.Handle.HandleEmail;
using PrintManagement.Application.ImplementServices;
using PrintManagement.Application.InterfaceServices;
using PrintManagement.Application.Payloads.Mappers;
using PrintManagement.Domain.Entities;
using PrintManagement.Domain.InterfaceRepositories.InterfaceBase;
using PrintManagement.Domain.InterfaceRepositories.InterfaceUser;
using PrintManagement.Infrastructure.DataContexts;
using PrintManagement.Infrastructure.ImplementRepositories.ImplementBase;
using PrintManagement.Infrastructure.ImplementRepositories.ImplementUser;
using System;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString(Constant.AppSettingKeys.DEFAULT_CONNECTION)), ServiceLifetime.Scoped);

builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:8080", "http://localhost:4200", "http://localhost:5173", "http://localhost:5174") // Update with your Angular app's URL
            .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});



#region Đăng ký converter
builder.Services.Convert();
#endregion


#region Đăng ký Repository

builder.Services.Register();
#endregion

#region Khác
builder.Services.Other();
#endregion



builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    // Set the expiration time for the OTP
    options.TokenLifespan = TimeSpan.FromMinutes(5); // Adjust the time span as needed
});

builder.Services.Configure<IdentityOptions>(
    opts => opts.SignIn.RequireConfirmedEmail = true
    );

builder.Services.AddAuthentication()
                        .AddMicrosoftAccount(microsoftOptions =>
                        {
                            microsoftOptions.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                            microsoftOptions.ClientId = "91eac13f-f506-42ad-92e9-c270b16c6e83";
                            microsoftOptions.ClientSecret = ".X55Ljxf/ut?[FwsMouFYT9KGIG5Y3iU";
                        })
                        .AddFacebook(facebookOptions =>
                        {
                            facebookOptions.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                            facebookOptions.AppId = "614218869377179";
                            facebookOptions.AppSecret = "7b81c3365e3a20ef205a05980b5204dd";
                        })
                        .AddGoogle(options =>
                        {
                            options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                            options.ClientId = "585809915555-74bvojk3mbf3gsqasp3hgmauhhc5e2pc.apps.googleusercontent.com";
                            options.ClientSecret = "L2417ys8xO7nbE3d4zxg7yvX";
                        });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,

        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]))
    };
});
builder.Services.AddMemoryCache();
var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
//app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
