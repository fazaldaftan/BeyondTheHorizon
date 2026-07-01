using UnityEngine;

/// <summary>
/// Credit management. No P2W. Rewards from discoveries, missions.
/// Integrates with Backend.
/// </summary>
public class EconomySystem : MonoBehaviour
{
    public float Credits { get; private set; }

    public void AwardCredits(float amount, string reason)
    {
        Credits += amount;
        // Sync to backend
        Debug.Log($"Earned {amount} credits for {reason}");
    }

    // Premium check (local + server)
}