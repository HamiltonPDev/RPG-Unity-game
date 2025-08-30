using UnityEngine;

/* This script makes the camera follow the player */

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject followTarget;
    [SerializeField]
    private UnityEngine.Vector3 targetPosition;
    [SerializeField]
    private float cameraSpeed = 4.0f;
    void Start()
    {
        // Auto-find player if not assigned
        if (followTarget == null)
        {
            followTarget = GameObject.FindWithTag("Player");
            if (followTarget == null)
            {
                followTarget = FindFirstObjectByType<PlayerController>()?.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Return early if no target assigned
        if (followTarget == null) return;
        
        // Target position camera
        targetPosition = new UnityEngine.Vector3(
            followTarget.transform.position.x,
            followTarget.transform.position.y,
            this.transform.position.z
        );
        this.transform.position = UnityEngine.Vector3.Lerp(
            this.transform.position,
            targetPosition,
            cameraSpeed * Time.deltaTime
        );
    }
}