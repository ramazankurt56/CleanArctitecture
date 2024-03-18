using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().WithMessage("Mail bilgisi boş olamaz");
        RuleFor(p => p.Email).NotNull().WithMessage("Mail bilgisi boş olamaz");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");

        RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı bilgisi boş olamaz");
        RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir."); 
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir."); 
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir.");
    }
}
