using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is for spawning designed zones */

public class SpawnZone : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;

    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();
        theCamera = FindFirstObjectByType<CameraFollow>();



        thePlayer.transform.position = this.transform.position;
        theCamera.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            theCamera.transform.position.z
        );

        thePlayer.lastMovement = facingDirection;
    }
}
