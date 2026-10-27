
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueLock.API.ModelsActualizados;

namespace TrueLock.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly TrueLockDbContext _context;

    public UsersController(TrueLockDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("roles")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _context.roles
            .Select(r => new
            {
                r.role_id,
                r.role_name,
                r.role_code
            })
            .ToListAsync();

        return Ok(roles);
    }
}
