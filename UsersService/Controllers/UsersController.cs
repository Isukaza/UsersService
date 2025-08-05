using Microsoft.AspNetCore.Mvc;
using UsersService.Managers;
using UsersService.Models.Requests;
using UsersService.Models.Responses;

namespace UsersService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserManager manager) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserInfo>> GetById(int id)
    {
        var user = await manager.GetByIdAsync(id);
        return user == null
            ? NotFound()
            : Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserInfo>>> GetAll()
    {
        var users = await manager.GetAllAsync();
        return Ok(users);
    }

    [HttpPost("create")]
    public async Task<ActionResult<UserInfo>> Create([FromBody] UserCreate userCreate)
    {
        var created = await manager.CreateAsync(userCreate);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<UserInfo>> Update([FromBody] UserUpdate userUpdate)
    {
        var updated = await manager.UpdateAsync(userUpdate);
        return updated == null
            ? NotFound()
            : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await manager.DeleteAsync(id);
        return deleted
            ? NoContent()
            : NotFound();
    }
}