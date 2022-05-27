namespace CalorieTracker.Api.CalorieEntries.Requests;

public class CreateCalorieEntryRequest
{
    public int FoodTypeId { get; init; }
    public double Quantity { get; init; }
    public DateTime Date { get; init; }
}
