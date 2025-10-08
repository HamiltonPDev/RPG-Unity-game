using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This script displays Spanish and English names when the player collides with objects
 * Part of the educational feature for Best Education B.V.
 */

public class SpanishObjectLabel : MonoBehaviour
{
    [Header("Object Names")]
    [Tooltip("Spanish name of the object (e.g., 'Árbol')")]
    public string spanishName = "Objeto";

    [Tooltip("English translation (e.g., 'Tree')")]
    public string englishName = "Object";

    [Header("Display Settings")]
    [Tooltip("Show the label when player is near this object")]
    public bool showOnProximity = true;

    [Tooltip("Distance to show label (only used if trigger collider is not present)")]
    public float displayDistance = 2f;

    [Header("Branding")]
    [Tooltip("Show Best Education B.V. branding on the label")]
    public bool showBranding = true;

    [Header("Timer Settings (for player only)")]
    [Tooltip("Use a timer to auto-hide label after x seconds (0 = disabled, stays visible)")]
    public float displayTimer = 3f;

    [Tooltip("Cooldown before label can be shown again (seconds)")]
    public float cooldownTimer = 5f;

    // Private timer variables
    private float currentDisplayTime = 0f;
    private float currentCooldownTime = 0f;
    private bool isOnCooldown = false;


    // Reference to the label UI manager
    private SpanishLabelUIManager uiManager;
    private bool isPlayerNearby = false;
    private Transform playerTransform;

    void Start()
    {
        // Find the UI manager in the scene
        uiManager = FindFirstObjectByType<SpanishLabelUIManager>();

        if (uiManager == null)
        {
            Debug.LogWarning("SpanishLabelUIManager not found in scene! Please add it to display labels.");
        }

        // Find the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // handle cooldown timer
        if (isOnCooldown)
        {
            currentCooldownTime -= Time.deltaTime;
            if (currentCooldownTime <= 0f)
            {
                isOnCooldown = false;
            }
            return; // Don't show label during the cooldown
        }

        // Handle display timer (auto-hide)
        if (isPlayerNearby && displayTimer > 0f)
        {
            currentDisplayTime -= Time.deltaTime;
            if (currentDisplayTime <= 0f)
            {
                HideLabel();
                isPlayerNearby = false;

                // Start cooldown
                isOnCooldown = true;
                currentCooldownTime = cooldownTimer;
                return;
            }
        }

        // If we don't have a trigger collider, check distance manually
        if (showOnProximity && playerTransform != null && uiManager != null)
        {
            float distance = Vector2.Distance(transform.position, playerTransform.position);

            if (distance <= displayDistance && !isPlayerNearby)
            {
                ShowLabel();
                isPlayerNearby = true;

                // Start timer if enabled
                if (displayTimer > 0f) currentDisplayTime = displayTimer;
            }
            else if (distance > displayDistance && isPlayerNearby)
            {
                HideLabel();
                isPlayerNearby = false;
            }
        }
    }

    // Trigger-based detection (for objects with trigger colliders)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowLabel();
            isPlayerNearby = true;

            // Start timer if enabled
            if (displayTimer > 0f) currentDisplayTime = displayTimer;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideLabel();
            isPlayerNearby = false;

            // Start cooldown if timer was used
            if (displayTimer > 0f)
            {
                isOnCooldown = true;
                currentCooldownTime = cooldownTimer;
            }
        }
    }

    // Show the label on the UI
    private void ShowLabel()
    {
        if (uiManager != null)
        {
            uiManager.ShowLabel(spanishName, englishName, showBranding);
        }
    }

    // Hide the label
    private void HideLabel()
    {
        if (uiManager != null)
        {
            uiManager.HideLabel();
        }
    }

    // Cleanup when object is destroyed
    void OnDestroy()
    {
        if (isPlayerNearby && uiManager != null)
        {
            uiManager.HideLabel();
        }
    }

    // Debug visualization in Scene view
    void OnDrawGizmosSelected()
    {
        // Draw the detection radius
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, displayDistance);
    }
}
