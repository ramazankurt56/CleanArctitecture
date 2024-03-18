using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
public sealed class RegisterCommandHandler(IAuthService authService) : IRequestHandler<RegisterCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await authService.RegisterAsync(request);
        return new("Kullanıcı kaydı başarıyla tamamlandı!");
    }
}
