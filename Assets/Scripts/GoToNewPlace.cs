using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* This script allows the player to go to a new scene when entering a trigger */

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Scene Name here";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadScene(newPlaceName);
        }
    }
}
