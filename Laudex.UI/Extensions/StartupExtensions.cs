namespace Laudex.UI.Extensions;

public static class StartupExtensions
{
    public static T AddAppConfigurationWithSettings<T>(this WebApplicationBuilder builder) where T : class, new()
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{env}.json", optional: true)
            .AddEnvironmentVariables()
        .Build();

        var instance = new T();

        var value = config.GetSection("AppSettings");

        value.Bind(instance);

        if (instance != null)
            builder.Services.AddSingleton(instance);

        return instance;
    }
}