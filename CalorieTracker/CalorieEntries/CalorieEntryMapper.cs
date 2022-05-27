using CalorieTracker.Api.CalorieEntries.Requests;
using CalorieTracker.Domain.CalorieEntries.DTO;

namespace CalorieTracker.Api.CalorieEntries
{
    public static class CalorieEntryMapper
    {
        public static CreateUpdateCalorieEntryDto MapToCreateDto(CreateCalorieEntryRequest request)
        {
            return new CreateUpdateCalorieEntryDto
            {
                Description = request.Description,
                FoodTypeId = request.FoodTypeId,
                Date = request.Date,
                Quantity = request.Quantity
            };
        }
    }
}
