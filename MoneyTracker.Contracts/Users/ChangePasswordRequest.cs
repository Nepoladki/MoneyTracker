using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTracker.Contracts.Users;

public record ChangePasswordRequest(
    Guid Id,
    string CurrentPassword,
    string NewPassword,
    string NewPasswordCopy);

