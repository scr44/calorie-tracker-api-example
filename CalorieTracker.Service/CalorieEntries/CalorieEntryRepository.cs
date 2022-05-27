using CalorieTracker.Domain.CalorieEntries;
using CalorieTracker.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Service.CalorieEntries;

public interface ICalorieEntryRepository
{
    Task<List<CalorieEntry>> GetAll(CancellationToken cancellationToken);
    Task<CalorieEntry> GetById(int id, CancellationToken cancellationToken);
    Task<int> Create(CalorieEntry entryItem, CancellationToken cancellationToken);
    Task Delete(int id, CancellationToken cancellationToken);
}

public class CalorieEntryRepository : ICalorieEntryRepository
{
    private ITrackerContext DbContext { get; set; }
    private DbSet<CalorieEntry> CalorieEntries => DbContext.CalorieEntry;

    public CalorieEntryRepository(ITrackerContext context)
    {
        DbContext = context;
    }

    public async Task<List<CalorieEntry>> GetAll(CancellationToken cancellationToken)
    {
        return await CalorieEntries.ToListAsync(cancellationToken);
    }

    public async Task<CalorieEntry> GetById(int id, CancellationToken cancellationToken)
    {
        return await CalorieEntries.SingleOrDefaultAsync(entry => entry.Id == id, cancellationToken)
            ?? throw new InvalidDataException($"CalorieEntry with id {id} not found.");
    }

    public async Task<int> Create(CalorieEntry entryItem, CancellationToken cancellationToken)
    {
        CalorieEntries.Add(entryItem);
        await DbContext.SaveChangesAsync(cancellationToken);
        return entryItem.Id;
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var entryItem = await CalorieEntries.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new InvalidDataException($"CalorieEntry with id {id} not found.");

        entryItem.Delete();
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
