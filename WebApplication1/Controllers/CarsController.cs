using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IRepository _repo;
    private readonly ILogger<CarsController> _logger;

    public CarsController(
        IRepository repo,
        ILogger<CarsController> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    // http://localhost:5085/api/Cars/
    [HttpGet]
    public List<Car> GetAll()
    {
        return _repo.GetAll();
    }

    // http://localhost:5085/api/Cars/
    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
        var car = _repo.GetById(id);
        if (car is null)
        {
            return NotFound();
        }

        return _repo.GetById(id);
    }

    [HttpGet("by-color")]
    public List<Car> GetByColor([FromQuery]string color)
    {
        return _repo.GetCarsByColor(color);
    }

    [HttpPost]
    public void Post(Car newCar)
    {
        _repo.Insert(newCar);
    }

    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        _repo.DeleteById(id);
        
    }

    [HttpPatch]
    public void Patch(Car newCar)
    {
        _repo.Update(newCar);
    }
}
