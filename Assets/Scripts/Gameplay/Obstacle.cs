using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    Attempts attempts;                                                          //References the scoreManager
    Vector3 currentPosition;
    GameObject player;
    GameObject trailRenderer;
    GameObject canvas;
    Shooting shooting;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        attempts = GameObject.Find("Attempts").GetComponent<Attempts>();     //References the scoreManager
        shooting = GameObject.Find("GunBarrel").GetComponent<Shooting>();
    }
    void OnTriggerEnter2D(Collider2D other)                                             //Checks for collision with the player
    {
        if(other.tag == "Player")   
        {
            shooting.isActive = false;
            DeathManager.killProjectile();
        }
    }
}
