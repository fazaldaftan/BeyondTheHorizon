using UnityEngine;

/// <summary>
/// Handles seamless transition from space to surface with procedural terrain.
/// Integrates with PlanetGenerator.
/// </summary>
public class PlanetLandingSystem : MonoBehaviour
{
    public void LandOnPlanet(PlanetData planet)
    {
        // Generate terrain using noise (Perlin or custom)
        // Spawn flora/fauna based on planet attributes
        Debug.Log($"Landing on {planet.Name} - Type: {planet.Type}");
        // Load scene additive or instantiate prefabs
        EventSystem.TriggerPlanetLanding(planet);

        // Initialize weather
        WeatherSystem weather = FindObjectOfType<WeatherSystem>();
        weather?.InitializeForPlanet(planet);
    }
}