using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)                                             //Checks for collision with the player
    {
        if(other.gameObject.tag == "PlayerOneProjectile")
        {
            DeathManager.killProjectile(other.gameObject);
        }
    }
}
