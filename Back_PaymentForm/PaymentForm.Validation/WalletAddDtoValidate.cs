using FluentValidation;
using PaymentForm.Core.DtoModels;

namespace PaymentForm.Validation;

public class WalletAddDtoValidate : AbstractValidator<WalletAddDto>
{
    public WalletAddDtoValidate()
    {
        RuleFor(w => w.WalletNumber)
            .Must(w => w == w.Trim())
            .WithMessage("Must without spaces")
            .Matches(@"^[0-9]+$")
            .MinimumLength(4)
            .MaximumLength(16)
            .NotEmpty();
        
        RuleFor(w => w.Balance)
            .GreaterThanOrEqualTo(1)
            .NotEmpty();

        RuleFor(w => w.UserId)
            .NotEmpty();
    }
}