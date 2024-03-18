using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
public class CreateNewTokenByRefreshTokenCommandValidator:AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User bilgisi bilgisi boş olamaz");
        RuleFor(p => p.UserId).NotNull().WithMessage("User adı boş olamaz");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refresh Token bilgisi boş olamaz.");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refresh Token bilgisi boş olamaz.");
    }
}
