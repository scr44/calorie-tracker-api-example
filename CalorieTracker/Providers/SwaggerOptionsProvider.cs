using System.Reflection;

namespace CalorieTracker.Api.Providers;

public static class SwaggerOptionsProvider
{
    public static IServiceCollection SetupSwaggerOptions(this IServiceCollection services)
    {
        return services.AddSwaggerGen(options =>
        {
            var version = "v1";
            options.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = version,
                Title = "CalorieTracker API",
                Description = "A sample ASP.NET Web API for tracking calories and food types."
            });
            
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), includeControllerXmlComments: true);
        });
    }
}
