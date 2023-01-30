
using WebApplication1;

public class Repository : IRepository
{
    private List<Car> _cars = new List<Car>();

    public void DeleteById(int id)
    {
        var carToDelete = _cars.First(x => x.Id == id);
        _cars.Remove(carToDelete);
    }

    public List<Car> GetAll()
    {
        return _cars;
    }

    public Car GetById(int id)
    {
        return _cars.Find(x => x.Id == id);
    }

    public List<Car> GetCarsByColor(string color)
    {
        return _cars
            .Where(x => x.Color == color)
            .ToList();
    }

    public void Insert(Car newCar)
    {
        _cars.Add(newCar);
    }

    public void Update(Car newCar)
    {
        var carToUpdate = _cars.First(x => x.Id == newCar.Id);
        carToUpdate.Brand = newCar.Brand;
    }
}
