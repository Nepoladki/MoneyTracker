using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Entries.Commands.AddEntry;
public class AddEntryCommandValidator : AbstractValidator<AddEntryCommand>
{
    public AddEntryCommandValidator()
    {
        RuleFor(x => x.Amount).NotEmpty().GreaterThan(0);
        RuleFor(x => x.DateTime).NotEmpty();
    }
}

