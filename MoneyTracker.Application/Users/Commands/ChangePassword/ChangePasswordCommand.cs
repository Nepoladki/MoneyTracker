using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Users.Commands.ChangePassword;

public record ChangePasswordCommand(
    Guid Id,
    string CurrentPassword,
    string NewPassword,
    string NewPasswordCopy) : IRequest<ErrorOr<Guid>>;