using FluentValidation;
using PayDayIdentityProject.DtoLayer.Dtos.AppUserDtos;

namespace PayDayIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage();
        }
    }
}
