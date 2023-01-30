using AutoFixture;
using AutoFixture.Xunit2;

namespace WebApplication1Tests;

public class CustomDataAttribute : AutoDataAttribute
{
	public CustomDataAttribute() : base(() =>
	{
        var fixture = new Fixture();
        fixture.Customizations.Add(new CarSpecimenBuilder());
        return fixture;
    })
	{ }
}
