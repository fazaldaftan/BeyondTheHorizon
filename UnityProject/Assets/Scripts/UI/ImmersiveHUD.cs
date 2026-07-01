using UnityEngine;
using TMPro;

/// <summary>
/// Minimal, immersive HUD. Hides when not needed.
/// </summary>
public class ImmersiveHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI discoveryLog;
    [SerializeField] private CanvasGroup hudGroup;

    public void LogDiscovery(DiscoveryData data)
    {
        discoveryLog.text += $"\n> {data.Name} discovered!";
        // Fade in/out for immersion
    }

    public void ToggleHUD(bool visible)
    {
        hudGroup.alpha = visible ? 1f : 0f;
    }
}