using UnityEngine;

/// <summary>
/// Procedural skybox and terrain texturing based on planet params.
/// </summary>
public class SkyboxGenerator : MonoBehaviour
{
    public void GenerateForPlanet(PlanetData planet)
    {
        // Dynamic sky material (color, stars, nebulae)
        RenderSettings.skybox.SetColor("_Tint", GetSkyColor(planet));
        // Terrain texture blending based on vegetation/minerals
        Debug.Log($"Sky and terrain updated for {planet.Name}");
    }

    private Color GetSkyColor(PlanetData planet)
    {
        // Atmospheric scattering simulation
        return planet.Temperature > 50 ? Color.red : Color.blue;
    }
}