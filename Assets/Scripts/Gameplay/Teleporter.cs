using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    [Tooltip("Where you want the teleporter to go")]
    public Transform newPosition;

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag.Equals("PlayerOneProjectile") || obj.tag.Equals("PlayerTwoProjectile"))
        {
            Wait(obj.gameObject);
        }
    }

    IEnumerator Wait(GameObject obj)
    {
        print("Collided with bullet");
        yield return new WaitForSeconds(5);

        obj.transform.position = newPosition.position;
        GetComponent<AudioSource>().Play();
    }
}

//~~~~No Fun Peter
