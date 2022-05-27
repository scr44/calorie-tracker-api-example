namespace CalorieTracker.Api.CalorieEntries.Requests;

public class CreateCalorieEntryRequest
{
    public string Description { get; init; } = null!;
    public int FoodTypeId { get; init; }
    public int Quantity { get; init; }
    public DateTime Date { get; init; }
}
