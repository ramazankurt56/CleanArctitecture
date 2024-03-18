namespace CleanArchitecture.Application.Services;
public interface IMailService
{
    Task<string> SendEmailAsync(string email, string subject, string body);
}
