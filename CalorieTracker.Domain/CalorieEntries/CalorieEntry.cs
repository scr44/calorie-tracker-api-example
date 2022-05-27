using CalorieTracker.Domain.Abstract;
using CalorieTracker.Domain.CalorieEntries.DTO;

namespace CalorieTracker.Domain.CalorieEntries;

public class CalorieEntry : DomainEntity
{
    public string Description { get; private set; } = null!;
    public int FoodTypeId { get; private set; }
    public int Quantity { get; private set; }
    public DateTime Date { get; private set; }

    public CalorieEntry(CreateUpdateCalorieEntryDto dto)
    {
        Description = dto.Description;
        FoodTypeId = dto.FoodTypeId;
        Quantity = dto.Quantity;
        Date = dto.Date;
        CreatedOn = DateTime.UtcNow;
    }
}
