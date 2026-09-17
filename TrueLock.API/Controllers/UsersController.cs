using Microsoft.AspNetCore.Mvc;
using TrueLock.API.Models;

namespace TrueLock.API.Controllers
{
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
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            return Ok(users);
        }
    }

}
