using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTracker.Application.Users.Commands.DeleteUser;
using MoneyTracker.Application.Users.Commands.UpdateUser;
using MoneyTracker.Application.Users.Common;
using MoneyTracker.Application.Users.Queries.GetUser;

namespace MoneyTracker.Api.Controllers;
[Route("/users")]
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
    public async Task<IActionResult> UpdateUser(Guid id, UserDto user)
    {
        var command = _mapper.Map<UpdateUserCommand>(user);
        command.Id = id;

        var updateResult = await _mediatr.Send(command);

        return updateResult.Match(guid => Ok(guid), Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var command = new DeleteUserCommand(id);

        var deleteResult = await _mediatr.Send(command);

        return deleteResult.Match(guid => Ok(guid), Problem);
    }
    

}