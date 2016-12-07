using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    [Tooltip("Where you want the teleporter to go")]
    public Transform newPosition;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("PlayerOneProjectile"))
        {
            obj.transform.position = newPosition.position;              // Move it to the new position.
            GetComponent<AudioSource>().Play();                         // Play the sound fx
        }
    }
}

//~~~~No Fun Peter
