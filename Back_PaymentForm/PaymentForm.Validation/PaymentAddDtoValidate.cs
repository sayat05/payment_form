using FluentValidation;
using PaymentForm.Core.DtoModels;

namespace PaymentForm.Validation;

public class PaymentAddDtoValidate : AbstractValidator<PaymentAddDto>
{
    public PaymentAddDtoValidate()
    {
        RuleFor(p => p.WalletNumber)
            .Must(w => w == w.Trim())
            .WithMessage("Must without spaces")
            .Matches(@"^[0-9]+$")
            .MinimumLength(4)
            .MaximumLength(16)
            .NotEmpty();

        RuleFor(p => p.UserId)
            .NotEmpty();

        RuleFor(p => p.Email)
            .Must(e => e == e.Trim())
            .WithMessage("Must without spaces")
            .EmailAddress()
            .NotEmpty();

        RuleFor(p => p.PhoneNumber)
            .Must(p => p == p.Trim())
            .WithMessage("Must without spaces")
            .Matches(@"^\+?\d{10,15}$")
            .WithMessage("Phone number must be valid (10-15 digits, optionally start with +).")
            .MinimumLength(10).WithMessage("Phone number is too short.")
            .MaximumLength(15).WithMessage("Phone number is too long.");

        RuleFor(p => p.Currency)
            .Must(c => c == c.Trim())
            .WithMessage("Must without spaces")
            .MinimumLength(3)
            .NotEmpty();

        RuleFor(p => p.Amount)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(p => p.Comment)
            .Must(c => c == c.Trim())
            .WithMessage("Must without spaces");
    }
}