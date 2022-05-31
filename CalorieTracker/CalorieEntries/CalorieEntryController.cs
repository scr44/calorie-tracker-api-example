using CalorieTracker.Api.CalorieEntries.Requests;
using CalorieTracker.Domain.CalorieEntries;
using CalorieTracker.Service.CalorieEntries;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Api.CalorieEntries;

[Route("calorie-entry")]
[ApiController]
public class CalorieEntryController : ControllerBase
{
    private readonly ICalorieEntryService _calorieEntryService;
    private readonly ICalorieEntryMapper _calorieEntryMapper;

    public CalorieEntryController(ICalorieEntryService calorieEntryService, ICalorieEntryMapper calorieEntryMapper)
    {
        _calorieEntryService = calorieEntryService;
        _calorieEntryMapper = calorieEntryMapper;
    }

    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> Get(int? id, CancellationToken cancellationToken)
    {
        if (id == null)
        {
            var result = await _calorieEntryService.GetAllCalorieEntries(cancellationToken);

            return Ok(result);
        }

        try
        {
            var calorieEntry = await _calorieEntryService.GetCalorieEntryById((int)id, cancellationToken);
            var result = new List<CalorieEntry> { calorieEntry };

            return Ok(result);
        }
        catch (InvalidDataException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Post([FromForm] CreateCalorieEntryRequest request, CancellationToken cancellationToken)
    {
        var dto = await _calorieEntryMapper.MapToCreateDto(request, cancellationToken);
        var result = await _calorieEntryService.CreateCalorieEntry(dto, cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _calorieEntryService.DeleteCalorieEntry(id, cancellationToken);

        return Ok();
    }
}
