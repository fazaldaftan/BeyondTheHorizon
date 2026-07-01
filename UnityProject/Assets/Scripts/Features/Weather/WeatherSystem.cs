using UnityEngine;
using System.Collections;

/// <summary>
/// Dynamic, planet-specific weather system.
/// Uses particle systems, shaders, and audio for immersion.
/// Observer integration for events.
/// </summary>
public class WeatherSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem rainParticles;
    [SerializeField] private ParticleSystem snowParticles;
    [SerializeField] private ParticleSystem windParticles;
    [SerializeField] private Light sunLight; // For storm darkening

    private PlanetData currentPlanet;
    private WeatherType currentWeather;
    private Coroutine weatherCoroutine;

    public enum WeatherType { Clear, Rain, Storm, Snow, Fog, Windy }

    public void InitializeForPlanet(PlanetData planet)
    {
        currentPlanet = planet;
        StartRandomWeatherCycle();
    }

    private void StartRandomWeatherCycle()
    {
        if (weatherCoroutine != null) StopCoroutine(weatherCoroutine);
        weatherCoroutine = StartCoroutine(WeatherCycle());
    }

    private IEnumerator WeatherCycle()
    {
        while (true)
        {
            currentWeather = GetRandomWeatherForPlanet();
            ApplyWeatherEffects(currentWeather);
            // Random duration 5-15 minutes real-time scaled
            yield return new WaitForSeconds(Random.Range(300f, 900f));
        }
    }

    private WeatherType GetRandomWeatherForPlanet()
    {
        // Bias based on planet attributes (e.g., high water % -> more rain)
        if (currentPlanet.Temperature < 0) return WeatherType.Snow;
        if (Random.value > 0.7f) return WeatherType.Storm;
        return WeatherType.Clear;
    }

    private void ApplyWeatherEffects(WeatherType weather)
    {
        // Disable all
        rainParticles?.Stop();
        snowParticles?.Stop();
        windParticles?.Stop();

        switch (weather)
        {
            case WeatherType.Rain:
                rainParticles?.Play();
                break;
            case WeatherType.Storm:
                rainParticles?.Play();
                // Thunder audio, lightning, reduced visibility
                if (sunLight) sunLight.intensity = 0.3f;
                break;
            case WeatherType.Snow:
                snowParticles?.Play();
                break;
            case WeatherType.Windy:
                windParticles?.Play();
                break;
        }

        Debug.Log($"Weather changed to: {weather} on {currentPlanet.Name}");
        // Trigger EventSystem for gameplay impact (e.g., reduced scan range in fog)
    }
}