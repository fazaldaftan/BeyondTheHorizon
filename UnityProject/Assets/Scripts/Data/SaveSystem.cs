using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // Or JSON + Addressables

/// <summary>
/// Full save/load with cloud sync hook.
/// Binary/JSON for cross-platform.
/// </summary>
public static class SaveSystem
{
    public static void SavePlayerProgress(PlayerProgress data)
    {
        string path = Path.Combine(Application.persistentDataPath, "progress.dat");
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
        // Sync to backend (async)
    }

    public static PlayerProgress LoadProgress()
    {
        string path = Path.Combine(Application.persistentDataPath, "progress.dat");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return formatter.Deserialize(stream) as PlayerProgress;
            }
        }
        return new PlayerProgress();
    }
}

[System.Serializable]
public class PlayerProgress
{
    public float Credits;
    public int ResearchPoints;
    public List<string> DiscoveredPlanets = new List<string>();
    // More...
}