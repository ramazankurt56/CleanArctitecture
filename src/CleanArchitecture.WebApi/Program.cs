using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Persistence.Respositories;
using CleanArchitecture.Persistence.Services;
using CleanArchitecture.WebApi.Middleware;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddTransient<ExceptionMiddleware>();


string? ConnectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(option=> option.UseSqlServer(ConnectionString));
builder.Services.AddIdentity<AppUser, Role>(cfr =>
{
    cfr.Password.RequiredLength = 1;
    cfr.Password.RequireNonAlphanumeric = false;
    cfr.Password.RequireUppercase = false;
    cfr.Password.RequireLowercase = false;
    cfr.Password.RequireDigit = false;
    cfr.SignIn.RequireConfirmedEmail = true;
    cfr.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    cfr.Lockout.MaxFailedAccessAttempts = 3;
    cfr.Lockout.AllowedForNewUsers = true;
})
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
builder.Services.AddControllers().
    AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

builder.Services.AddMediatR(cfr=>cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistence.AssemblyReference).Assembly);   

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUnitOfWork>(cfr => cfr.GetRequiredService<AppDbContext>());

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
