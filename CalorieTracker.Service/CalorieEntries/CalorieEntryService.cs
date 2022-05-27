using CalorieTracker.Domain.CalorieEntries;
using CalorieTracker.Domain.CalorieEntries.DTO;

namespace CalorieTracker.Service.CalorieEntries;

public interface ICalorieEntryService
{
    Task<List<CalorieEntry>> GetAllCalorieEntries(CancellationToken cancellationToken);
    Task<CalorieEntry> GetCalorieEntryById(int id, CancellationToken cancellationToken);
    Task<int> CreateCalorieEntry(CreateCalorieEntryDto dto, CancellationToken cancellationToken);
    Task DeleteCalorieEntry(int id, CancellationToken cancellationToken);
}

public class CalorieEntryService : ICalorieEntryService
{
    private ICalorieEntryRepository Repository { get; set; }

    public CalorieEntryService(ICalorieEntryRepository repository)
    {
        // There's an argument to be made that EF Core obviates the need for a repository
        // layer at all. For example purposes and unit testing, I'm including it in this case.

        Repository = repository;
    }

    public async Task<List<CalorieEntry>> GetAllCalorieEntries(CancellationToken cancellationToken)
    {
        return await Repository.GetAll(cancellationToken);
    }

    public async Task<CalorieEntry> GetCalorieEntryById(int id, CancellationToken cancellationToken)
    {
        return await Repository.GetById(id, cancellationToken);
    }

    public async Task<int> CreateCalorieEntry(CreateCalorieEntryDto dto, CancellationToken cancellationToken)
    {
        return await Repository.Create(new CalorieEntry(dto), cancellationToken);
    }

    public async Task DeleteCalorieEntry(int id, CancellationToken cancellationToken)
    {
        await Repository.Delete(id, cancellationToken);
    }
}
