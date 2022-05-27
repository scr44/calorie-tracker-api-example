using NUnit.Framework;
using Moq;
using CalorieTracker.Service.FoodTypes;
using CalorieTracker.Api.FoodTypes;

namespace CalorieTracker.UnitTests.FoodTypes;

public class FoodTypeControllerFixture
{
    // This is just a very small sampling to demonstrate Moq. In a true project there
    // would be tests for the 404 and other actions as well, and fixtures for the service
    // and repository layers. For these trivial CRUD calls though, that's a lot of boilerplate
    // testing, so I'm going to leave it at this.

    protected FoodTypeController _controller;
    protected Mock<IFoodTypeService> _foodTypeService;
    protected CancellationToken _cancellationToken;

    [SetUp]
    public void Setup()
    {
        _foodTypeService = new Mock<IFoodTypeService>();
        _controller = new FoodTypeController(_foodTypeService.Object);
        _cancellationToken = It.IsAny<CancellationToken>();
    }

    [Test]
    public async Task Get_retrieves_single_entity_if_id_provided()
    {
        var id = 1;
        _foodTypeService.Setup(x => x.GetFoodTypeById(id, _cancellationToken));
        await _controller.Get(id, _cancellationToken);

        _foodTypeService.Verify(x => x.GetFoodTypeById(id, _cancellationToken), Times.Once());
    }

    [Test]
    public async Task Get_retrieves_multiple_entities_if_id_is_null()
    {
        _foodTypeService.Setup(x => x.GetAllFoodTypes(_cancellationToken));
        await _controller.Get(null, _cancellationToken);

        _foodTypeService.Verify(x => x.GetAllFoodTypes(_cancellationToken), Times.Once());
    }
}
