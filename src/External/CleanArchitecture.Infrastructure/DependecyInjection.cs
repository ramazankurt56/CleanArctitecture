using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;
public static class DependecyInjection
{
    public static IServiceCollection AddDataAccess(
     this IServiceCollection services,
     IConfiguration configuration)
    {
        services.AddScoped<IMailService, MailService>();
        
        services.Configure<EmailOptions>(configuration.GetSection("EmailSettings"));
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.ConfigureOptions<JwtTokenOptionsSetup>();
        services.AddAuthentication().AddJwtBearer();

        
        return services;
    }
}
