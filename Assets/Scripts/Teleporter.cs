using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    [Tooltip("Where you want the teleporter to go")]
    public Transform newPosition;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("Player"))
        {
            obj.transform.position = newPosition.position;
        }
    }
}

//~~~~Peter
