using Microsoft.Extensions.Hosting;
using TrueLockAgent;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "TrueLockAgent";
});

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();