using Duende.IdentityServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
options.UseSqlServer(builder.Configuration.GetConnectionString(Constant.AppSettingKeys.DEFAULT_CONNECTION)));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder
            .WithOrigins("http://localhost:4200") // Update with your Angular app's URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IBaseReposiroty<User>, BaseRepository<User>>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDbContext, ApplicationDbContext>();
builder.Services.AddScoped<ProjectConverter>();
builder.Services.AddScoped<DesignConverter>();
builder.Services.AddScoped<UserConverter>();
builder.Services.AddScoped<CustomerConverter>();
builder.Services.AddScoped<IDesignService, DesignService>();
builder.Services.AddScoped<DesignConverter>();
builder.Services.AddScoped<ICustomerFeedbackService, CustomerFeedbackService>();
builder.Services.AddScoped<CustomerFeedbackConverter>();
builder.Services.AddScoped<CustomerFeedbackConverter>();
builder.Services.AddScoped<IUserRepository<User>, UserRepository<User>>();
builder.Services.AddScoped<IBaseReposiroty<RefreshToken>, BaseRepository<RefreshToken>>();
builder.Services.AddScoped<IBaseReposiroty<ConfirmEmail>, BaseRepository<ConfirmEmail>>();
builder.Services.AddScoped<IBaseReposiroty<Customer>, BaseRepository<Customer>>();  
builder.Services.AddScoped<IBaseReposiroty<Project>,  BaseRepository<Project>>();
builder.Services.AddScoped<IBaseReposiroty<Design>,  BaseRepository<Design>>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IBaseReposiroty<ImportCoupon>, BaseRepository<ImportCoupon>>();
builder.Services.AddScoped<ResourcePropertyDetailConverter>();
builder.Services.AddScoped<ResourcePropertyConverter>();
builder.Services.AddScoped<TeamConverter>();
builder.Services.AddScoped<IBaseReposiroty<Team>, BaseRepository<Team>>();
builder.Services.AddScoped<IBaseReposiroty<ResourceProperty>, BaseRepository<ResourceProperty>>();
builder.Services.AddScoped<IBaseReposiroty<ResourcePropertyDetail>, BaseRepository<ResourcePropertyDetail>>();
builder.Services.AddScoped<IBaseReposiroty<Resource>, BaseRepository<Resource>>();
builder.Services.AddScoped<IBaseReposiroty<Permissions>, BaseRepository<Permissions>>();
builder.Services.AddScoped<IBaseReposiroty<Role>, BaseRepository<Role>>();
builder.Services.AddScoped<ResourcePropertyConverter>();
builder.Services.AddScoped<ResourceConverter>();
builder.Services.AddScoped<ImportCouponConverter>();
builder.Services.AddScoped<IImportCouponService, ImportCouponService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<ResourcePropertyDetailConverter>();
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
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
