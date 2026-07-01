using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Procedural music and adaptive soundscapes.
/// Uses FMOD or Unity Audio + parameters for planet mood.
/// </summary>
public class ProceduralAudioSystem : MonoBehaviour
{
    [SerializeField] private AudioSource ambientSource;
    [SerializeField] private AudioSource musicSource;

    private PlanetData currentPlanet;
    private List<AudioClip> planetAmbients = new List<AudioClip>(); // Populate procedurally or via bank

    public void InitializeForPlanet(PlanetData planet)
    {
        currentPlanet = planet;
        PlayPlanetSoundscape();
        StartAdaptiveMusic();
    }

    private void PlayPlanetSoundscape()
    {
        // Generate or select ambient based on biome (wind, creatures, water)
        if (ambientSource)
        {
            // Example: Crossfade to new clip
            ambientSource.Play();
        }
    }

    private void StartAdaptiveMusic()
    {
        // Procedural generation or parameter-driven (e.g., intensity based on exploration)
        // Music evolves with discoveries, danger, wonder
        musicSource?.Play();
    }

    // Call from events: e.g., on discovery -> uplifting shift
    public void OnDiscovery(DiscoveryData data)
    {
        // Modulate music parameters
    }
}