using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace TrueLock.API.Controllers
{
    [ApiController]
    [Route("api/database")]
    public class DatabaseTestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DatabaseTestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            string connectionString =
                _configuration.GetConnectionString("TrueLockDatabase");

            try
            {
                using var connection = new MySqlConnection(connectionString);

                connection.Open();

                string sql = "SELECT user_id FROM users LIMIT 5;";

                using var command = new MySqlCommand(sql, connection);

                using var reader = command.ExecuteReader();

                var users = new List<long>();

                while (reader.Read())
                {
                    long userId = reader.GetInt64("user_id");

                    users.Add(userId);
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("test")]
        public IActionResult TestConnection()
        {
            string connectionString =
                _configuration.GetConnectionString("TrueLockDatabase");

            try
            {
                using var connection = new MySqlConnection(connectionString);

                connection.Open();

                return Ok("Conexión exitosa con true_lock_db");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error de conexión: {ex.Message}");
            }
        }
    }
}