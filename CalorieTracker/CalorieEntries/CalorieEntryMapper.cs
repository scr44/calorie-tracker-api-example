using CalorieTracker.Api.CalorieEntries.Requests;
using CalorieTracker.Domain.CalorieEntries.DTO;
using CalorieTracker.Service.CalorieEntries;
using CalorieTracker.Service.FoodTypes;

namespace CalorieTracker.Api.CalorieEntries
{
    public interface ICalorieEntryMapper
    {
        Task<CreateCalorieEntryDto> MapToCreateDto(CreateCalorieEntryRequest request, CancellationToken cancellationToken);
    }

    public class CalorieEntryMapper : ICalorieEntryMapper
    {
        private IFoodTypeService _service;

        public CalorieEntryMapper(IFoodTypeService service)
        {
            _service = service;
        }

        public async Task<CreateCalorieEntryDto> MapToCreateDto(CreateCalorieEntryRequest request, CancellationToken cancellationToken)
        {
            var foodType = await _service.GetFoodTypeById(request.FoodTypeId, cancellationToken);

            return new CreateCalorieEntryDto
            {
                FoodType = foodType,
                FoodTypeId = request.FoodTypeId,
                Date = request.Date,
                Quantity = request.Quantity
            };
        }
    }
}
