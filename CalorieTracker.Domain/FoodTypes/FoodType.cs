using CalorieTracker.Domain.Abstract;
using CalorieTracker.Domain.FoodTypes.DTO;

namespace CalorieTracker.Domain.FoodTypes;

public class FoodType : DomainEntity
{
    public string Name { get; private set; } = null!;
    public double CaloriesPerUnit { get; private set; }
    public Units Units { get; private set; }

    public FoodType(CreateFoodTypeDto dto)
    {
        Name = dto.Name;
        CaloriesPerUnit = dto.CaloriesPerUnit;
        Units = dto.Units;
        CreatedOn = DateTime.UtcNow;
    }

    public void Update(UpdateFoodTypeDto dto)
    {
        Name = dto.Name ?? Name;
        CaloriesPerUnit = dto.CaloriesPerUnit ?? CaloriesPerUnit;
        Units = dto.Units ?? Units;
    }
}
