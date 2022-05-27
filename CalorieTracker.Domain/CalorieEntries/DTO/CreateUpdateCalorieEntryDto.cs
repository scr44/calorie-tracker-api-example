namespace CalorieTracker.Domain.CalorieEntries.DTO;

public sealed class CreateUpdateCalorieEntryDto
{
    public string Description { get; init; } = null!;
    public int FoodTypeId { get; init; }
    public int Quantity { get; init; }
    public DateTime Date { get; init; }
}
