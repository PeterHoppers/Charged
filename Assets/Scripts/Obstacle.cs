using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    Attempts attempts;                                                          //References the scoreManager
    Vector3 currentPosition;
    GameObject player;
    GameObject trailRenderer;
    GameObject canvas;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        attempts = GameObject.Find("Attempts").GetComponent<Attempts>();     //References the scoreManager
        player = GameObject.FindGameObjectWithTag("Player");
        trailRenderer = player.transform.FindChild("TrailRenderer").gameObject;
    }
    void OnTriggerEnter2D(Collider2D other)                                             //Checks for collision with the player
    {
        if(other.gameObject == player)   
        {
            DeathManager.killProjectile();
        }
    }
}
