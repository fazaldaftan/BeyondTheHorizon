using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Diplomacy & NPC AI using Utility AI + Behavior Trees.
/// Influenced by culture, player reputation, history.
/// </summary>
public class DiplomacySystem : MonoBehaviour
{
    public float PlayerReputation { get; private set; } = 50f; // 0-100

    public FirstContactOutcome InitiateContact(CivilizationData civ)
    {
        float roll = Random.value * 100;
        if (PlayerReputation > 70) roll += 20;

        if (roll > 80) return FirstContactOutcome.Cooperative;
        if (roll > 60) return FirstContactOutcome.Curious;
        // Fearful, Aggressive, etc. based on civ traits

        return FirstContactOutcome.Friendly;
    }

    public void ApplyDecision(Decision decision)
    {
        // Update reputation, relations
        PlayerReputation = Mathf.Clamp(PlayerReputation + decision.ReputationDelta, 0, 100);
    }
}

public enum FirstContactOutcome { Friendly, Curious, Fearful, Isolated, Aggressive, Cooperative }

public class CivilizationData { /* From generator */ }