using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player movement, interaction, and exploration modes (walk, drive, fly, swim).
/// Strategy pattern for different locomotion modes.
/// Single Responsibility: Input + Locomotion.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jumpHeight = 2f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction scanAction;

    private LocomotionStrategy currentStrategy;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        // Input setup (new Input System)
        // TODO: Wire full InputActions
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;
        HandleMovement();
        HandleInteractions();
    }

    private void HandleMovement()
    {
        // Use currentStrategy.Move() - allows switching modes (e.g., jetpack flight)
        if (currentStrategy != null)
        {
            currentStrategy.Execute(this);
        }
        // Gravity & basic physics
        if (isGrounded && velocity.y < 0) velocity.y = -2f;
        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleInteractions()
    {
        // Scan, Mine, Document via raycast or sphere
        if (scanAction.WasPerformedThisFrame())
        {
            PerformScan();
        }
    }

    private void PerformScan()
    {
        // Raycast forward, detect objects, trigger EventSystem
        EventSystem.TriggerDiscovery("Scan", "New data logged");
        // Integrate with ResearchSystem
    }

    // Public API for mode switching (e.g., enter vehicle)
    public void SetLocomotionStrategy(LocomotionStrategy strategy)
    {
        currentStrategy = strategy;
    }
}

public interface ILocomotionStrategy
{
    void Execute(PlayerController player);
}

// Example concrete strategies (Walking, Flying, etc.)
public class WalkingStrategy : ILocomotionStrategy
{
    public void Execute(PlayerController player) { /* movement logic */ }
}