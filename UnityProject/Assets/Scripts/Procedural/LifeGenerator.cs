using UnityEngine;

/// <summary>
/// Strategy-based life form generation tied to planet biome/conditions.
/// </summary>
public class LifeGenerator
{
    public void PopulatePlanet(PlanetData planet)
    {
        // Generate plants, animals, intelligent species based on params
        if (planet.Temperature > 0 && planet.Temperature < 50)
        {
            // Temperate biome - more biodiversity
        }
        // DNA traits, behaviors, etc.
    }
}