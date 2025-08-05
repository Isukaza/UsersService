using Microsoft.AspNetCore.Mvc;
using UsersService.Managers;
using UsersService.Models;

namespace UsersService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserManager manager) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfo>>> GetAll()
    {
        var users = await manager.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserInfo>> GetById(int id)
    {
        var user = await manager.GetByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
}