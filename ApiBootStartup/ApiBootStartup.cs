namespace Libraries;

/// <summary>
/// Classe abstrata que implementa IStartup e deve ser herdada por uma classe Startup na inicialização de uma WebApi
/// Contém configurações básicas refrequentemente utilizadas por uma API
/// </summary>
public abstract class ApiBootStartup : IStartup
{
    public IConfiguration Configuration { get; }

    public ApiBootStartup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected abstract void ConfigureWebApiServices(IServiceCollection services);
    protected abstract void ConfigureWebApi(WebApplication app, IWebHostEnvironment env);

    public void Configure(WebApplication app, IWebHostEnvironment environment)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        ConfigureWebApi(app, environment);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureWebApiServices(services);

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}