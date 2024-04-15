using System;
using System.Security.Claims;
using System.Text;
using EasyTraningsAPI.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using AutoMapper;
using EasyTraningsAPI.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EasyTraningsAPI.Models.Configuration;
using EasyTraningsAPI.Models.Configuration.GenericEnum;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using EasyTraningsAPI.Models.DTOs;
using EasyTraningsAPI.Repositories;
using EasyTraningsAPI.Repositories.Generic;
using EasyTraningsAPI.Repositories.Interfaces;
using EasyTraningsAPI.Services.Interfaces;
using EasyTraningsAPI.Services.Interfaces.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

var mapperConfiguration = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<GenericEnumToDtoProfile>();
    cfg.AddProfile<EntityToDtoAndReverse>();
});

var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "EasyTrainings",
        Description = "An ASP.NET Core Web API of EasyTrainings",
        TermsOfService = new Uri("https://easy-trainings/terms"),
        Contact = new OpenApiContact
        {
            Name = "Aleska Malikova",
            Url = new Uri("https://easy-trainings/contact")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://easy-trainings/license")
        }
    });
    
    options.MapType<Guid>(() => new OpenApiSchema { Type = "string", Format = null });
    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
});

var connectionString = builder.Configuration.GetConnectionString("DB");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddCustomCorsPolicy();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITranningRepository, TranningRepository>();
builder.Services.AddScoped<ISeasonTicketRepository, SeasonTicketRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITranningService, TranningService>();
builder.Services.AddScoped<ISeasonTicketService, SeasonTicketService>();


var app = builder.Build();

app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
