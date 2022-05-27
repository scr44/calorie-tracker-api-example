using CalorieTracker.Domain.Abstract;
using CalorieTracker.Domain.CalorieEntries.DTO;

namespace CalorieTracker.Domain.CalorieEntries;

public class CalorieEntry : DomainEntity
{
    public string FoodTypeName { get; private set; } = null!;
    public int FoodTypeId { get; private set; }
    public double Quantity { get; private set; }
    public double Calories { get; private set; }
    public DateTime Date { get; private set; }

    public CalorieEntry(CreateCalorieEntryDto dto)
    {
        var foodType = dto.FoodType;
        FoodTypeName = foodType.Name;
        FoodTypeId = dto.FoodTypeId;
        Quantity = dto.Quantity;
        Calories = foodType.CaloriesPerUnit * Quantity;
        Date = dto.Date;
        CreatedOn = DateTime.UtcNow;
    }
}
