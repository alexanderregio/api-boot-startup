namespace Libraries;

/// <summary>
/// Extensão da classe Startup
/// Objetivo de utilizar classes com a interface IStartup na classe program de uma WebApi
/// </summary>
public static class StartupExtensions
{
    public static WebApplicationBuilder UseStartup<TStartup>
        (this WebApplicationBuilder webApplicationBuilder)
            where TStartup : IStartup
    {
        var startup = Activator.CreateInstance
            (typeof(TStartup), webApplicationBuilder.Configuration)
                as IStartup;

        if (startup is null)
            throw new ArgumentNullException(nameof(startup));

        startup.ConfigureServices(webApplicationBuilder.Services);

        var app = webApplicationBuilder.Build();

        startup.Configure(app, app.Environment);

        app.Run();

        return webApplicationBuilder;
    }
}
