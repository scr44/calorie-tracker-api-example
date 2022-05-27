using CalorieTracker.Domain.Abstract;

namespace CalorieTracker.Domain.FoodTypes.DTO;

public class CreateFoodTypeDto
{
    public string Name { get; init; } = null!;
    public double CaloriesPerUnit { get; init; }
    public Units Units { get; init; }
}
