using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1;
using WebApplication1.Controllers;

namespace WebApplication1Tests;

public class CarsControllerTests1
{
    private readonly IFixture _fixture;

    public CarsControllerTests1()
    {
        _fixture = new Fixture();
    }

    [Theory, CustomData]
    public void GetById_CarExistsInRepository_ReturnCar(Car car)
    {
        // Arrange
        var repo = new Mock<IRepository>();
        repo.Setup(x => x.GetById(It.IsAny<int>()))
            .Returns(car);
        var logger = new Mock<ILogger<CarsController>>();
        var sut = new CarsController(repo.Object, logger.Object);

        // Act
        ActionResult<Car> response = sut.GetById(1);

        // Assert
        Assert.Equal(car, response.Value);
    }

    [Fact]
    public void GetById_CarNotExistsInRepository_ReturnNotFound()
    {
        // Arrange
        var repo = new Mock<IRepository>();
        repo.Setup(x => x.GetById(It.IsAny<int>()))
            .Returns(null as Car);
        var logger = new Mock<ILogger<CarsController>>();
        var sut = new CarsController(repo.Object, logger.Object);

        // Act
        ActionResult<Car> response = sut.GetById(1);

        // Assert
        var type = response.Result.GetType();
        Assert.Equal("NotFoundResult", type.Name);
    }

    [Fact]
    public void GetColor_TwoCarExistsInRepository_ReturnCar()
    {
        // Arrange
        var testCars = new List<Car>
        {
            _fixture.Create<Car>(),
            _fixture.Create<Car>(),
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