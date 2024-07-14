using FluentValidation;

namespace MoneyTracker.Application.Entries.Commands.UpdateEntry;

public class UpdateEntryCommandValidator : AbstractValidator<UpdateEntryCommand>
{
    public UpdateEntryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.CurrencyAbbr).NotEmpty();
        RuleFor(x => x.DateTime).NotEmpty();
    }
}

