using EasyCashIdentityProject.DTOLayer.Dtos.AppUserDtos;
using FluentValidation;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            _ = RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.").MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapın").MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            _ = RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            _ = RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı alanı boş geçilemez.").EmailAddress().WithMessage("Lütfen geçerli bir email adresi girişi yapın.");
            _ = RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.");
            _ = RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            _ = RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez.").Equal(x => x.Password).WithMessage("Parolalarınız eşleşmiyor");
        }
    }
}