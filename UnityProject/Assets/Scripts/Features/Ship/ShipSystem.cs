using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Builder pattern for ship upgrades.
/// Central hub for interior, systems, and travel.
/// </summary>
public class ShipSystem : MonoBehaviour
{
    public ShipStats Stats { get; private set; } = new ShipStats();

    public void UpgradeModule(string module)
    {
        switch (module)
        {
            case "WarpEngine":
                Stats.WarpRange += 50;
                break;
            // Add more: Shields, Scanner, Lab, etc.
        }
        Debug.Log($"Upgraded {module}. New range: {Stats.WarpRange}");
        // Persist + visual changes in interior
    }

    public void EnterShipInterior()
    {
        // Load interior scene or activate UI
        // AI Assistant dialogue
    }
}

public class ShipStats
{
    public float WarpRange { get; set; } = 100f;
    public float Fuel { get; set; } = 100f;
    // Shields, Cargo, etc.
}