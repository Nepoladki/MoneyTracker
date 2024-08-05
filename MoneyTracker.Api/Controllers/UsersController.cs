using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Users.Commands.ChangePassword;
using MoneyTracker.Application.Users.Commands.DeleteUser;
using MoneyTracker.Application.Users.Commands.UpdateUser;
using MoneyTracker.Application.Users.Common;
using MoneyTracker.Application.Users.Queries.GetUser;
using MoneyTracker.Contracts.Users;

namespace MoneyTracker.Api.Controllers;
[Route("api/users")]
[Authorize]
public class UsersController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public UsersController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();

        var usersResult = await _mediatr.Send(query);

        return usersResult.Match(u => Ok(u.Adapt<IList<UserDto>>()), Problem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var query = new GetUserQuery(id);

        var getUserResult = await _mediatr.Send(query);

        return getUserResult.Match(u => Ok(u.Adapt<UserDto>()), Problem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
    {
        var command = _mapper.Map<UpdateUserCommand>(request);

        var updateResult = await _mediatr.Send(command);

        return updateResult.Match(guid => Ok(guid), Problem);
    }

    [HttpPut("{id}/change_password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var command = _mapper.Map<ChangePasswordCommand>(request);

        var changePasswordResult = await _mediatr.Send(command);

        return changePasswordResult.Match(guid => Ok(guid), Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var command = new DeleteUserCommand(id);

        var deleteResult = await _mediatr.Send(command);

        return deleteResult.Match(guid => Ok(guid), Problem);
    }
}