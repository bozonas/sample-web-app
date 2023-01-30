
using WebApplication1;

public interface IRepository
{
    List<Car> GetAll();

    Car GetById(int id);

    List<Car> GetCarsByColor(string color);

    void Insert(Car newCar);

    void DeleteById(int id);

    void Update(Car newCar);
}