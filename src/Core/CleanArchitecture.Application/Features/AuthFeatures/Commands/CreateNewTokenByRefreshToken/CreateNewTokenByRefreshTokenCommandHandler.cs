using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
public sealed class CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService) : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
        return response;
    }
}
