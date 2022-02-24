namespace MinimalToStartup;

public class Startup : ApiBootStartup
{
    public Startup(IConfiguration configuration)
        : base(configuration) { }

    protected override void ConfigureWebApi(WebApplication app, IWebHostEnvironment env) { }
    protected override void ConfigureWebApiServices(IServiceCollection services) { }
}

