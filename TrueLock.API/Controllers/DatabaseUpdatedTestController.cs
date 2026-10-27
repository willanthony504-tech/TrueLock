
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueLock.API.ModelsActualizados;

namespace TrueLock.API.Controllers;

[ApiController]
[Route("api/database-updated-test")]
public class DatabaseUpdatedTestController : ControllerBase
{
    private readonly TrueLockDbContext _context;

    public DatabaseUpdatedTestController(TrueLockDbContext context)
    {
        _context = context;
    }

    [HttpGet("applications")]
    public async Task<IActionResult> GetApplications()
    {
        var count = await _context.applications.CountAsync();
        return Ok(new { table = "applications", count });
    }
}
