using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Manages research points, unlocks, and discovery logging.
/// Repository pattern for local + cloud sync.
/// </summary>
public class ResearchSystem : MonoBehaviour
{
    public int ResearchPoints { get; private set; }
    private HashSet<string> DiscoveredEntries = new HashSet<string>();

    public void AddDiscovery(DiscoveryData data)
    {
        if (DiscoveredEntries.Add(data.Name))
        {
            ResearchPoints += (int)(data.ScientificValue * 10);
            // Persist + Backend sync
            Debug.Log($"New discovery: {data.Name} | RP: {ResearchPoints}");
            // Unlock logic (Strategy for upgrade trees)
        }
    }

    // TODO: UI integration, cloud repo
}