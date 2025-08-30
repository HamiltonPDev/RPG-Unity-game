using System;
using System.Numerics;
using UnityEngine;

/* This script controls the player character */

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    private bool walking = false;
    public UnityEngine.Vector2 lastMovement = UnityEngine.Vector2.zero;
    private const string horizontalInput = "Horizontal";
    private const string verticalInput = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";

    private Animator animator;
    private Rigidbody2D playerRigidbody2D;

    /* If the player is created */
    public static bool playerCreated;

    public string nextPlaceName;
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
        playerRigidbody2D = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component

        if (!playerCreated) // If the player is created
        {
            playerCreated = true; // Mark the player as created
            DontDestroyOnLoad(this.gameObject); // Prevent the player from being destroyed on scene load
        }
        else
        {
            Destroy(this.gameObject); // Destroy the duplicate player
        }
    }

    // Update is called once per frame
    void Update()
    {
        // space =  velocity * Time.deltaTime 
        walking = false;

        if (Mathf.Abs(Input.GetAxisRaw(horizontalInput)) > 0.5f)
        {
            /* Move the player horizontally */
            playerRigidbody2D.linearVelocity = new UnityEngine.Vector2(Input.GetAxisRaw(horizontalInput) * speed, playerRigidbody2D.linearVelocity.y);
            walking = true;
            lastMovement = new UnityEngine.Vector2(Input.GetAxisRaw(horizontalInput), 0);
        }
        if (Mathf.Abs(Input.GetAxisRaw(verticalInput)) > 0.5f)
        {
            /* Move the player vertically */
            playerRigidbody2D.linearVelocity = new UnityEngine.Vector2(playerRigidbody2D.linearVelocity.x, Input.GetAxisRaw(verticalInput) * speed);
            walking = true;
            lastMovement = new UnityEngine.Vector2(0, Input.GetAxisRaw(verticalInput));
        }

        if (!walking) playerRigidbody2D.linearVelocity = UnityEngine.Vector2.zero;
        // Update the animator parameters based on input
        animator.SetFloat("Horizontal", Input.GetAxisRaw(horizontalInput));
        animator.SetFloat("Vertical", Input.GetAxisRaw(verticalInput));

        /* Update the walking state */
        animator.SetBool(walkingState, walking);

        /* Last movement */
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);
    }
}
