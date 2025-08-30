using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script prevents the GameObject from being destroyed when loading a new scene */

public class DontDestroyOnload : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
