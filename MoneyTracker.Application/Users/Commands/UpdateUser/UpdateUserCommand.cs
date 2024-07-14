using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ErrorOr<Guid>>
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
}

