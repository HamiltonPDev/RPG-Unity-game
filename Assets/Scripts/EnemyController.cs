using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This script controls the enemy character randomly */
public class EnemyController : MonoBehaviour
{
    public float enemySpeed = 1.0f; // Speed of the enemy
    private Rigidbody2D enemyRigidbody; // Rigidbody2D component of the enemy

    private bool isMoving; // Is the enemy currently moving?

    public float timeBetweenSteps; // Time between each movement step
    private float timeBetweenStepsCounter; // Counter for time between steps

    public float timeToMakeStep; // Time to make each step
    private float timeToMakeStepCounter; // Counter for time to make steps

    public Vector2 directionToMakeStep; // Direction to make each step

    private Animator enemyAnimator; // Animator component of the enemy
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime; // Decrease the step counter
            enemyRigidbody.linearVelocity = directionToMakeStep; // move the enemy to an any direction

            if (timeToMakeStepCounter < 0)
            {
                isMoving = false; // Stop moving
                timeBetweenStepsCounter = timeBetweenSteps; // Reset the time between steps counter
                enemyRigidbody.linearVelocity = Vector2.zero; // Stop the enemy
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime; // Decrease the time between steps counter

            if (timeBetweenStepsCounter < 0) // If the time between steps is over
            {
                isMoving = true; // Start moving
                timeToMakeStepCounter = timeToMakeStep; // Reset the time to make step counter
                directionToMakeStep = new Vector2(Random.Range(-1f, 2f), Random.Range(-1f, 2f)) * enemySpeed; // Get the random direction
            }
        }
        enemyAnimator.SetFloat(horizontal, directionToMakeStep.x); // Set the horizontal animation parameter
        enemyAnimator.SetFloat(vertical, directionToMakeStep.y); // Set the vertical animation parameter
    }
}
