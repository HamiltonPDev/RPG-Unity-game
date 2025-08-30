using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script prevents the GameObject from being destroyed when loading a new scene */

public class DontDestroyOnload : MonoBehaviour
{
    // Awake is called when the script instance is being loaded
    void Awake()
    {
        if (!PlayerController.playerCreated)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
