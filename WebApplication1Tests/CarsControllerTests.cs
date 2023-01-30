using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1;
using WebApplication1.Controllers;

namespace WebApplication1Tests;

public class CarsControllerTests
{
    private readonly IFixture _fixture;

    public CarsControllerTests()
    {
        _fixture = new Fixture().Customize( new AutoMoqCustomization());
    }

    [Theory, AutoData]
    public void GetById_CarExistsInRepository_ReturnCar(Car car)
    {
        // Arrange
        var repo = _fixture.Freeze<Mock<IRepository>>();
        repo.Setup(x => x.GetById(It.IsAny<int>()))
            .Returns(car);

        // Act
        var sut = _fixture.Build<CarsController>()
            .OmitAutoProperties()
            .Create();
        var response = sut.GetById(1);

        // Assert
        Assert.Equal(car, response);
    }

    [Fact]
    public void GetColor_TwoCarExistsInRepository_ReturnCar()
    {
        // Arrange
        var testCars = new List<Car>
        {
            new Car
            {
                Id = 1,
                Brand = "bmw",
                Color = "white",
            },
            new Car
            {
                Id = 2,
                Brand = "audi",
                Color = "red",
            },
        };
        var repo = new Mock<IRepository>();
        repo.Setup(x => x.GetCarsByColor(It.IsAny<string>()))
            .Returns(testCars);
        var logger = new Mock<ILogger<CarsController>>();
        var sut = new CarsController(repo.Object, logger.Object);

        // Act
        var response = sut.GetByColor("asdasd");

        // Assert
        Assert.Equal(testCars, response);
    }
}