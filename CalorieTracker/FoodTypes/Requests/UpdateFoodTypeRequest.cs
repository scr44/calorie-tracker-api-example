using CalorieTracker.Domain.Abstract;

namespace CalorieTracker.Api.FoodTypes.Requests;

public class UpdateFoodTypeRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public double? CaloriesPerUnit { get; init; }
    public Units? Units { get; init; }
}
