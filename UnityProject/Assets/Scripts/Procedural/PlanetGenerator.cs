using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Factory and Builder pattern for procedural planet generation.
/// Ensures unique planets with scientific attributes.
/// </summary>
public class PlanetGenerator : MonoBehaviour
{
    private System.Random random = new System.Random();

    public PlanetData GeneratePlanet(Vector3 coordinates, long seed)
    {
        random = new System.Random((int)(seed ^ coordinates.GetHashCode())); // Deterministic

        PlanetData planet = new PlanetData
        {
            Name = GeneratePlanetName(),
            Type = (PlanetType)random.Next(0, System.Enum.GetValues(typeof(PlanetType)).Length),
            Gravity = random.Next(0.5f, 2.5f),
            Temperature = random.Next(-100, 150),
            // ... more attributes
            Seed = seed
        };

        GenerateLifeForms(planet);
        GenerateCivilization(planet);

        return planet;
    }

    private string GeneratePlanetName()
    {
        // Procedural name generation logic
        string[] prefixes = { "Zor", "Xan", "Neb", "Aether" };
        string[] suffixes = { "ion", "ara", "thos", "prime" };
        return prefixes[random.Next(prefixes.Length)] + suffixes[random.Next(suffixes.Length)];
    }

    private void GenerateLifeForms(PlanetData planet)
    {
        // Use Strategy pattern for different biomes
        // TODO: Implement detailed life generation
    }

    private void GenerateCivilization(PlanetData planet)
    {
        if (random.NextDouble() > 0.7) // 30% chance
        {
            planet.HasCivilization = true;
            // CivilizationGenerator
        }
    }
}

public enum PlanetType { Terrestrial, GasGiant, IceWorld, Lava, Ocean, Desert }

public class PlanetData
{
    public string Name { get; set; }
    public PlanetType Type { get; set; }
    public float Gravity { get; set; }
    public float Temperature { get; set; }
    public bool HasCivilization { get; set; }
    public long Seed { get; set; }
    // Add more properties as per spec
}