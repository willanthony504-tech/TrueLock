using Microsoft.EntityFrameworkCore;
using TrueLock.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Conexión con la base de datos
builder.Services.AddDbContext<TrueLockDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("TrueLockDatabase"),
        ServerVersion.Parse("8.4.11-mysql")
    ));

// OpenAPI
builder.Services.AddOpenApi();

var app = builder.Build();

// OpenAPI solamente durante desarrollo
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();