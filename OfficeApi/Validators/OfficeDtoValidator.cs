using FluentValidation;
using OfficeApi.DTOs;

namespace OfficeApi.Validators
{
    public class OfficeDtoValidator : AbstractValidator<OfficeDto>
    {
        public OfficeDtoValidator()
        {
            RuleFor(o => o.City)
                .NotEmpty().WithMessage("City is Required")
                .MaximumLength(50).WithMessage("City cannot be longer than 50 characters");

            RuleFor(o => o.Street)
                .NotEmpty().WithMessage("Street is Required")
                .MaximumLength(50).WithMessage("Street cannot be longer than 50 characters");

            RuleFor(o => o.OfficeNumber)
                .NotEmpty().WithMessage("Office number is Required")
                .MaximumLength(50).WithMessage("Office number cannot be longer than 50 characters");

            RuleFor(o => o.HouseNumber)
                .NotEmpty().WithMessage("House number is Required")
                .MaximumLength(50).WithMessage("House number cannot be longer than 50 characters");

            RuleFor(o => o.RegistryPhoneNumber)
                .NotEmpty().WithMessage("Registry phone number is required")
                .Matches(@"^\+\d+$").WithMessage("Registry phone number must contain only digits and start with '+'");
        }
    }
}
