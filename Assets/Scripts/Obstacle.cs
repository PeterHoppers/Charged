using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    Attempts attempts;                                                          //References the scoreManager

    void Start()
    {
        attempts = GameObject.Find("Attempts").GetComponent<Attempts>();     //References the scoreManager
    }

    void OnTriggerEnter2D(Collider2D other)                                             //Checks for collision with the player
    {
        if(other.tag == "Player")   
        {
            Destroy(other.gameObject);                                                             //Destroyes the player and updates the score
            attempts.Attempted();
        }
    }
}
