using Microsoft.AspNetCore.Mvc;

namespace UsersService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public IActionResult Test() => Ok("Test");
}