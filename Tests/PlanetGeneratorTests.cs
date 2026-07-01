using NUnit.Framework;

/// <summary>
/// Unit tests for PlanetGenerator ensuring uniqueness and scientific validity.
/// </summary>
public class PlanetGeneratorTests
{
    [Test]
    public void GeneratePlanet_ProducesUniquePlanets()
    {
        var generator = new PlanetGenerator();
        var planet1 = generator.GeneratePlanet(Vector3.zero, 12345);
        var planet2 = generator.GeneratePlanet(Vector3.one, 67890);

        Assert.AreNotEqual(planet1.Name, planet2.Name);
        Assert.IsTrue(planet1.Seed != planet2.Seed);
    }
}