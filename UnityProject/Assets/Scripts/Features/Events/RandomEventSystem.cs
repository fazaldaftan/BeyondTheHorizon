using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Generates meaningful random events using weighted probabilities.
/// Observer pattern integration for player choices.
/// </summary>
public class RandomEventSystem : MonoBehaviour
{
    private System.Random random = new System.Random();

    public void TriggerRandomEvent(PlanetData currentPlanet)
    {
        float roll = (float)random.NextDouble();
        if (roll < 0.2f) HandleSolarStorm();
        else if (roll < 0.4f) HandleAlienDistress();
        // Add more: meteor, ruins, virus, etc.
        else Debug.Log("Quiet exploration continues...");
    }

    private void HandleSolarStorm()
    {
        // Affect ship systems, force choices
        EventSystem.TriggerDiscovery("Event", "Solar Storm - Shields at risk");
    }

    private void HandleAlienDistress()
    {
        // Diplomatic decision tree
    }
}