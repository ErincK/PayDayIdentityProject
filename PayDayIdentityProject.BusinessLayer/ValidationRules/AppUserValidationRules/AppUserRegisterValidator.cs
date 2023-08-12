using FluentValidation;
using PayDayIdentityProject.DtoLayer.Dtos.AppUserDtos;

namespace PayDayIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter girişi yapabilirsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter girişi yapabilirsiniz");
            RuleFor(x => x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz");
        }
    }
}
