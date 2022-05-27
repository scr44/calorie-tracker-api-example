using CalorieTracker.Domain.Abstract;

namespace CalorieTracker.Api.FoodTypes.Requests;

public class CreateFoodTypeRequest
{
    public string Name { get; init; } = null!;
    public double CaloriesPerUnit { get; init; }
    public Units Units { get; init; }
}
