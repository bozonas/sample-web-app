using AutoFixture.Kernel;
using WebApplication1;

namespace WebApplication1Tests;

public class CarSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is Type type && type == typeof(Car))
        {
            return new Car
            {
                Id = 1,
                Brand = "bmw",
                Color = "white",
            };
        }
        return new NoSpecimen();
    }
}
