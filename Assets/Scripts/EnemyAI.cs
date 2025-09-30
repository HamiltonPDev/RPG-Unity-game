using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("AI Detection Settings")]
    public float detectionRange = 5f; // How far the enemy can see the player
    public float chaseSpeed = 3f; // Speed when chasing player
    public float patrolSpeed = 1f; // Speed when patrolling
    public float attackRange = 1.5f; // Distance to start attacking

    [Header("Patrol Settings")]
    public Transform[] patrolPoints; // Points to patrol between
    public float waitTime = 2f; // Time to wait at each patrol point

    private Transform player; // Reference to the player
    private Rigidbody2D enemyRigidbody; // Reference to the enemy's rigidbody
    private int currentPatrolIndex = 0; // Index of the current patrol point
    private float waitTimer = 0f; // timer for waiting at patrol points 

    /* AI States */
    private enum EnemyState
    {
        Patrol,
        Chase,
        Attack,
        Idle
    }
    private EnemyState currentState = EnemyState.Patrol; // Initial state

    void Start()
    {
        // Get components
        enemyRigidbody = GetComponent<Rigidbody2D>();

        // Find the player by tag
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        // If not patrol points set, create a simple back-and-forth patrol
        if (patrolPoints == null || patrolPoints.Length == 0) CreateDefaultPatrolPoints();
    }


    void Update()
    {
        if (player == null) return; // safety check

        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // State machine logic
        switch (currentState)
        {
            case EnemyState.Patrol:
                HandlePatrolState(distanceToPlayer);
                break;
            case EnemyState.Chase:
                HandleChaseState(distanceToPlayer);
                break;
            case EnemyState.Attack:
                HandleAttackState(distanceToPlayer);
                break;
            case EnemyState.Idle:
                HandleIdleState(distanceToPlayer);
                break;
        }
    }

    /* Handle patrol behavior - move between patrol points */
    private void HandlePatrolState(float distanceToPlayer)
    {

        // check if player is in detection range
        if (distanceToPlayer <= detectionRange) ChangeState(EnemyState.Chase);

        // Move towards current patrol point
        if (patrolPoints.Length > 0)
        {
            Vector2 targetPosition = patrolPoints[currentPatrolIndex].position;
            MoveTowards(targetPosition, patrolSpeed);

            if (Vector2.Distance(transform.position, targetPosition) < 0.5f)
            {
                ChangeState(EnemyState.Idle);
            }
        }
    }

    /* Handle chase behavior - pursue the player */
    private void HandleChaseState(float distanceToPlayer)
    {
        // If player is too far, return to patrol
        if (distanceToPlayer > detectionRange * 1.5f) ChangeState(EnemyState.Patrol);

        // If close enough to attack
        if (distanceToPlayer <= attackRange) ChangeState(EnemyState.Attack);

        // Chase the player
        MoveTowards(player.position, chaseSpeed);
    }

    /* Handle attack behavior - stop and attack */
    private void HandleAttackState(float distanceToPlayer)
    {
        // Stop moving when attacking
        enemyRigidbody.linearVelocity = Vector2.zero;

        // If the player moves away, return to chase
        if (distanceToPlayer > attackRange * 1.2f) ChangeState(EnemyState.Chase);

        /* attacking logic would go here (animation, damage dealing, etc)
            for now, just stay in attack state.
        */
    }

    /* Handle Idle behavior - wait at patrol point */
    private void HandleIdleState(float distanceToPlayer)
    {
        // Check if player is in detection range
        if (distanceToPlayer <= detectionRange) ChangeState(EnemyState.Chase);

        // Stop movement
        enemyRigidbody.linearVelocity = Vector2.zero;

        // Wait at patrol point 
        waitTimer += Time.deltaTime;
        if (waitTimer >= waitTime)
        {
            // Move to next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            waitTimer = 0f;
            ChangeState(EnemyState.Patrol);
        }
    }

    /* Move towards a target position */
    private void MoveTowards(Vector2 targetPosition, float speed)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        enemyRigidbody.linearVelocity = direction * speed;
    }

    /* Change AI state */
    private void ChangeState(EnemyState newState)
    {
        currentState = newState;

        // reset timers when changing state
        if (newState == EnemyState.Idle) waitTimer = 0f;
    }

    /*  Create default points if none are set */
    private void CreateDefaultPatrolPoints()
    {

        /* Creating two patrol points: current position +/- 3 units on x axis */
        GameObject point1 = new GameObject("PatrolPoint1");
        GameObject point2 = new GameObject("PatrolPoint2");

        point1.transform.position = transform.position + Vector3.left * 3f;
        point2.transform.position = transform.position + Vector3.right * 3f;

        patrolPoints = new Transform[] { point1.transform, point2.transform };
    }

    /*
        This is an extra,
        Debug visualization in Scene view
    */
    private void OnDrawGizmosSelected()
    {
        // Draw detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Draw attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Draw patrol points and connections
        if (patrolPoints != null && patrolPoints.Length > 1)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                if (patrolPoints[i] != null)
                {
                    // Draw patrol point
                    Gizmos.DrawWireSphere(patrolPoints[i].position, 0.5f);

                    int nextIndex = (i + 1) % patrolPoints.Length;
                    if (patrolPoints[nextIndex] != null)
                    {
                        Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[nextIndex].position);
                    }
                }
            }
        }
    }
}
