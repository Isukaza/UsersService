using Microsoft.AspNetCore.Mvc;
using UsersService.Managers;
using UsersService.Models.Requests;
using UsersService.Models.Responses;

namespace UsersService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController(ISubscriptionManager manager) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubscriptionInfo>> GetById(int id)
    {
        var subscription = await manager.GetByIdAsync(id);
        return subscription == null ? NotFound() : Ok(subscription);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionInfo>>> GetAll()
    {
        var subscriptions = await manager.GetAllAsync();
        return Ok(subscriptions);
    }

    [HttpPost("create")]
    public async Task<ActionResult<SubscriptionInfo>> Create([FromBody] SubscriptionCreate subscriptionCreate)
    {
        var created = await manager.CreateAsync(subscriptionCreate);
        return StatusCode(StatusCodes.Status201Created, created);
    }

    [HttpPut("update")]
    public async Task<ActionResult<SubscriptionInfo>> Update([FromBody] SubscriptionUpdate subscriptionUpdate)
    {
        var updated = await manager.UpdateAsync(subscriptionUpdate);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await manager.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}