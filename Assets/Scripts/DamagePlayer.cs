using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float timeToRevivePlayer;
    private float timeToRevivalCounter;
    private bool playerReviving;

    private GameObject thePlayer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerReviving)
        {
            timeToRevivalCounter -= Time.deltaTime;

            if (timeToRevivalCounter < 0)
            {
                playerReviving = false;
                thePlayer.SetActive(true);
            }
        }
    }

    /* OnCollisionEnter2D is for detecting player collisions */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            thePlayer = collision.gameObject;
            thePlayer.SetActive(false);
            playerReviving = true;
            timeToRevivalCounter = timeToRevivePlayer;
        }
    }
}
