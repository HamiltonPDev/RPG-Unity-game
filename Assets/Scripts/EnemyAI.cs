using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("AI Detection Settings")]
    public float detectionRange = 5f;
    public float chaseSpeed = 3f;
    public float attackRange = 1.5f;

    [Header("Patrol Settings")]
    public Transform[] patrolPoints;
    public float waitTime = 2f;

    private Transform player; // Reference to the player
    private Rigidbody2D enemyRigidbody; // Reference to the enemy's rigidbody
    private int currentPatrolIndex = 0; // Index of the current patrol point
    private float waitCounter = 0f; // Counter for the wait time

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
}
