using CalorieTracker.Domain.FoodTypes;

namespace CalorieTracker.Domain.CalorieEntries.DTO;

public sealed class CreateCalorieEntryDto
{
    public FoodType FoodType { get; init; } = null!;
    public int FoodTypeId { get; init; }
    public double Quantity { get; init; }
    public DateTime Date { get; init; }
}
