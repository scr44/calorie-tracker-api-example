using CalorieTracker.Api.FoodTypes.Requests;
using CalorieTracker.Domain.FoodTypes;
using CalorieTracker.Service.FoodTypes;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Api.FoodTypes
{
    [Route("api/food-type")]
    [ApiController]
    public class FoodTypeController : ControllerBase
    {
        private readonly IFoodTypeService _foodTypeService;

        public FoodTypeController(IFoodTypeService foodTypeService)
        {
            _foodTypeService = foodTypeService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                var result = await _foodTypeService.GetAllFoodTypes(cancellationToken);

                return Ok(result);
            }

            try
            {
                var foodType = await _foodTypeService.GetFoodTypeById((int)id, cancellationToken);
                var result = new List<FoodType> { foodType };

                return Ok(result);
            }
            catch (InvalidDataException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromForm] CreateFoodTypeRequest request, CancellationToken cancellationToken)
        {
            var dto = FoodTypeMapper.MapToCreateDto(request);
            var newId =  await _foodTypeService.CreateFoodType(dto, cancellationToken);

            return Ok(newId);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromForm] UpdateFoodTypeRequest request, CancellationToken cancellationToken)
        {
            var dto = FoodTypeMapper.MapToUpdateDto(request);
            await _foodTypeService.UpdateFoodType(dto, cancellationToken);

            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _foodTypeService.DeleteFoodType(id, cancellationToken);

            return Ok();
        }
    }
}
