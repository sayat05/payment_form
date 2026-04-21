using FluentValidation;
using PaymentForm.Core.DtoModels;

namespace PaymentForm.Validation;

public class UserAddDtoValidate : AbstractValidator<UserAddDto>
{
    public UserAddDtoValidate()
    {
        RuleFor(u => u.Name)
            .Must(n => n == n.Trim())
            .WithMessage("Must without spaces")
            .MinimumLength(2)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(u => u.Email)
            .Must(e => e == e.Trim())
            .WithMessage("Must without spaces")
            .EmailAddress()
            .NotEmpty();

        RuleFor(u => u.PhoneNumber)
            .Must(p => p == p.Trim())
            .WithMessage("Must without spaces")
            .Matches(@"^\+?\d{10,15}$")
            .WithMessage("Phone number must be valid (10-15 digits, optionally start with +).")
            .MinimumLength(10).WithMessage("Phone number is too short.")
            .MaximumLength(15).WithMessage("Phone number is too long.");
    }
}