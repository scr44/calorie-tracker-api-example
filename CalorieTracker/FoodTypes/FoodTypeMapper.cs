using CalorieTracker.Api.FoodTypes.Requests;
using CalorieTracker.Domain.FoodTypes.DTO;

namespace CalorieTracker.Api.FoodTypes
{
    public static class FoodTypeMapper
    {
        public static CreateFoodTypeDto MapToCreateDto(CreateFoodTypeRequest request)
        {
            return new CreateFoodTypeDto
            {
                Name = request.Name,
                CaloriesPerUnit = request.CaloriesPerUnit,
                Units = request.Units
            };
        }

        public static UpdateFoodTypeDto MapToUpdateDto(UpdateFoodTypeRequest request)
        {
            return new UpdateFoodTypeDto
            {
                Id = request.Id,
                Name = request.Name,
                CaloriesPerUnit = request.CaloriesPerUnit,
                Units = request.Units
            };
        }
    }
}
