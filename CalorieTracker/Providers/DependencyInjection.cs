using CalorieTracker.Service.CalorieEntries;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace CalorieTracker.Api.Providers;

public static class DependencyInjection
{
    public static void RegisterServicesAndRepositoriesForDependencyInjection(this IServiceCollection service)
    {
        // see https://github.com/JonPSmith/NetCore.AutoRegisterDi

        var assembliesToScan = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(ICalorieEntryRepository)),
            Assembly.GetAssembly(typeof(ICalorieEntryService))
        };

        var results = service.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository") || c.Name.EndsWith("Mapper"))
            .AsPublicImplementedInterfaces();
    }
}
