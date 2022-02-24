namespace ApiBoot;

/// <summary>
/// Interface para implementação da classe Startup
/// </summary>
public interface IStartup
{
    void Configure(WebApplication app, IWebHostEnvironment environment);
    void ConfigureServices(IServiceCollection services);
}