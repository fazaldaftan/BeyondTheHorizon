using UnityEngine;
using System;

/// <summary>
/// Observer pattern implementation for game events.
/// Decouples systems for better maintainability.
/// </summary>
public static class EventSystem
{
    public static event Action<string, object> OnDiscovery;
    public static event Action<PlanetData> OnPlanetLanded;

    public static void TriggerDiscovery(string type, object data)
    {
        OnDiscovery?.Invoke(type, data);
    }

    public static void TriggerPlanetLanding(PlanetData planet)
    {
        OnPlanetLanded?.Invoke(planet);
    }
}