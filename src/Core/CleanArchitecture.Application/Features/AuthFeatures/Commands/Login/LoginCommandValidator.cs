using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
public sealed class LoginCommandValidator:AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı bilgisi boş olamaz");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir.");
    }
}
