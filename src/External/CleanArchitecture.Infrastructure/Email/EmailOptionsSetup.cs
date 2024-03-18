using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Infrastructure.OptionsSetup;
//public sealed class EmailOptionsSetup(IConfiguration configuration) : IConfigureOptions<EmailOptions>
//{
//    public void Configure(EmailOptions options)
//    {
//        configuration.GetSection("EmailSettings").Bind(options);
//    }
//}