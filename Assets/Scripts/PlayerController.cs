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
    private const string attackingState = "Attacking";
    
    // Components
    private Animator animator;
    private Rigidbody2D playerRigidbody2D;

    /* If the player is created */
    public static bool playerCreated;
    public string nextPlaceName;

    /* Attacking variables */
    private bool attacking = false;
    public float attackTime;
    private float attackTimeCounter;

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

        /* attacking button and animation */
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            attackTimeCounter = attackTime;
            playerRigidbody2D.linearVelocity = UnityEngine.Vector2.zero; // Stop the player movement
            animator.SetBool(attackingState, true);
        }

        if (attacking)
        {
            attackTimeCounter -= Time.deltaTime;
            if (attackTimeCounter <= 0)
            {
                attacking = false;
                animator.SetBool(attackingState, false);
            }
            return; // Skip the rest of the update while attacking
        }
        else
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontalInput)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(verticalInput)) > 0.5f)
            {
                walking = true;
                lastMovement = new UnityEngine.Vector2(
                    Input.GetAxisRaw(horizontalInput),
                    Input.GetAxisRaw(verticalInput));

                playerRigidbody2D.linearVelocity = lastMovement.normalized * speed; // Move the player
            }
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
