using UnityEngine;

/// <summary>
/// Respectful, non-intrusive premium upgrade after tutorial.
/// </summary>
public class PremiumPrompt : MonoBehaviour
{
    public void ShowAfterTutorial()
    {
        // Nice UI panel: "Continue exploring the full universe?"
        // Benefits list, one-time purchase
        Debug.Log("Premium prompt shown - Unlimited galaxies & multiplayer unlocked");
    }
}