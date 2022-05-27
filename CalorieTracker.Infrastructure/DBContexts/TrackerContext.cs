using CalorieTracker.Domain.Abstract;
using CalorieTracker.Domain.CalorieEntries;
using CalorieTracker.Domain.FoodTypes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CalorieTracker.Infrastructure.DBContexts;

public interface ITrackerContext
{
    DbSet<FoodType> FoodType { get; set; }
    DbSet<CalorieEntry> CalorieEntry { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class TrackerContext : DbContext, ITrackerContext
{
    public DbSet<FoodType> FoodType { get; set; } = null!;
    public DbSet<CalorieEntry> CalorieEntry { get; set; } = null!;

    public TrackerContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // This could be done more elegantly by filtering soft deletes on DomainEntity instead...
        // but then we run into the issue of having a separate domain entity table in
        // the database. EFC does not yet support table-per-concrete configs, but should
        // soon: https://docs.microsoft.com/en-us/ef/core/modeling/inheritance

        modelBuilder.Entity<FoodType>().HasQueryFilter(x => x.DeletedOn == null);
        modelBuilder.Entity<CalorieEntry>().HasQueryFilter(x => x.DeletedOn == null);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
