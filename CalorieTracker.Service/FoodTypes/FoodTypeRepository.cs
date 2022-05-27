using CalorieTracker.Domain.FoodTypes;
using CalorieTracker.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Service.FoodTypes;

public interface IFoodTypeRepository
{
    Task<List<FoodType>> GetAll(CancellationToken cancellationToken);
    Task<FoodType> GetById(int id, CancellationToken cancellationToken);
    Task<int> Create(FoodType foodType, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}

public class FoodTypeRepository : IFoodTypeRepository
{
    private ITrackerContext DbContext { get; set; }
    private DbSet<FoodType> Foods => DbContext.FoodType;

    public FoodTypeRepository(ITrackerContext context)
    {
        DbContext = context;
    }

    public async Task<List<FoodType>> GetAll(CancellationToken cancellationToken)
    {
        return await Foods.ToListAsync(cancellationToken);
    }

    public async Task<FoodType> GetById(int id, CancellationToken cancellationToken)
    {
        return await Foods.SingleOrDefaultAsync(f => f.Id == id, cancellationToken)
            ?? throw new InvalidDataException($"FoodType with id {id} not found.");
    }

    public async Task<int> Create(FoodType foodType, CancellationToken cancellationToken)
    {
        Foods.Add(foodType);
        await DbContext.SaveChangesAsync(cancellationToken);
        return foodType.Id;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
