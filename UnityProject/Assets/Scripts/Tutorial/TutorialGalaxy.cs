using UnityEngine;

/// <summary>
/// Guided first session: Limited galaxy with tutorial planets.
/// Ends with premium prompt.
/// </summary>
public class TutorialGalaxy : MonoBehaviour
{
    public PlanetGenerator generator;
    private int tutorialPlanetsVisited = 0;

    public void StartTutorial()
    {
        // Generate 3-5 tutorial planets with guided steps
        PlanetData firstPlanet = generator.GeneratePlanet(Vector3.zero, 1001);
        // Force friendly civilization, simple scans
    }

    public void OnPlanetCompleted()
    {
        tutorialPlanetsVisited++;
        if (tutorialPlanetsVisited >= 3)
        {
            FindObjectOfType<PremiumPrompt>()?.ShowAfterTutorial();
        }
    }
}