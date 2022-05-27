using CalorieTracker.Api.CalorieEntries.Requests;
using CalorieTracker.Domain.CalorieEntries;
using CalorieTracker.Service.CalorieEntries;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Api.CalorieEntries;

[Route("api/[controller]")]
[ApiController]
public class CalorieEntryController : ControllerBase
{
    private readonly ICalorieEntryService _calorieEntryService;

    public CalorieEntryController(ICalorieEntryService calorieEntryService)
    {
        _calorieEntryService = calorieEntryService;
    }

    // <summary>
    // this is a summary
    // </summary>
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
    public async Task<IActionResult> Post([FromBody] CreateCalorieEntryRequest request, CancellationToken cancellationToken)
    {
        var dto = CalorieEntryMapper.MapToCreateDto(request);
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
