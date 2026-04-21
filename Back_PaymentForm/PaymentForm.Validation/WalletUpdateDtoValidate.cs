using FluentValidation;
using PaymentForm.Core.DtoModels;

namespace PaymentForm.Validation;

public class WalletUpdateDtoValidate : AbstractValidator<WalletUpdateDto>
{
    public WalletUpdateDtoValidate()
    {
        RuleFor(w => w.WalletNumber)
            .Must(w => w == w.Trim())
            .WithMessage("Must without spaces")
            .Matches("^[0-9]+$")
            .MinimumLength(4)
            .MaximumLength(16)
            .NotEmpty();

        RuleFor(w => w.Sum)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();
    }
}