using ErrorOr;
using MediatR;

namespace MoneyTracker.Application.Entries.Commands.DeleteEntry;

public record DeleteEntryCommand(Guid id) : IRequest<ErrorOr<Guid>>;