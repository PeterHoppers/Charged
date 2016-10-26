using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    ScoreManager scoreManager;                                                          //References the scoreManager

    void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();     //References the scoreManager
    }

    void OnTriggerEnter2D(Collider2D other)                                             //Checks for collision with the player
    {
        if(other.tag == "Player")   
        {
            Destroy(other.gameObject);                                                             //Destroyes the player and updates the score
            scoreManager.UpdateScore();
        }
    }
}
