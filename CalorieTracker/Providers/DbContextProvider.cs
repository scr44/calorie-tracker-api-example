using CalorieTracker.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Api.Providers;

public static class DbContextProvider
{
    public static IServiceCollection AddSqliteDbContext(this IServiceCollection serviceCollection)
    {
        var dbPath = $"../database.db";

        return serviceCollection
            .AddDbContext<ITrackerContext, TrackerContext>(options =>
                options.UseSqlite($"Data Source={dbPath}")
                );
    }
}
