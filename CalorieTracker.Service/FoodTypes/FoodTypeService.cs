using CalorieTracker.Domain.FoodTypes;
using CalorieTracker.Domain.FoodTypes.DTO;

namespace CalorieTracker.Service.FoodTypes;

public interface IFoodTypeService
{
    Task<List<FoodType>> GetAllFoodTypes(CancellationToken cancellationToken);
    Task<FoodType> GetFoodTypeById(int id, CancellationToken cancellationToken);
    Task<int> CreateFoodType(CreateFoodTypeDto dto, CancellationToken cancellationToken);
    Task UpdateFoodType(UpdateFoodTypeDto dto, CancellationToken cancellationToken);
    Task DeleteFoodType(int id, CancellationToken cancellationToken);
}

public class FoodTypeService : IFoodTypeService
{
    private IFoodTypeRepository Repository { get; set; }

    public FoodTypeService(IFoodTypeRepository repository)
    {
        Repository = repository;
    }

    public async Task<List<FoodType>> GetAllFoodTypes(CancellationToken cancellationToken)
    {
        return await Repository.GetAll(cancellationToken);
    }

    public async Task<FoodType> GetFoodTypeById(int id, CancellationToken cancellationToken)
    {
        return await Repository.GetById(id, cancellationToken);
    }

    public async Task<int> CreateFoodType(CreateFoodTypeDto dto, CancellationToken cancellationToken)
    {
        var createdId = await Repository.Create(new FoodType(dto), cancellationToken);

        return createdId;
    }

    public async Task UpdateFoodType(UpdateFoodTypeDto dto, CancellationToken cancellationToken)
    {
        var foodType = await Repository.GetById(dto.Id, cancellationToken);
        foodType.Update(dto);

        await Repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteFoodType(int id, CancellationToken cancellationToken)
    {
        var foodType = await Repository.GetById(id, cancellationToken);
        foodType.Delete();

        await Repository.SaveChangesAsync(cancellationToken);
    }
}
