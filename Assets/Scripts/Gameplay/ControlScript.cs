using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
    [Header("Minimum and Maximum rotation")]
    [Range(0,180)]
    public float maxRotation = 15;
    [Range(-180, 0)]
    public int minRotation = -15;
    [Header("How fast the object spins")]
    [TextArea(0,2)]
    public string note = "Note: speed may affect the min and max rotation";
    public float speed = 2.0f;
    float wait;
    float curTurn = 0;
	void Update () 
    {
        //aiming up
        if (Input.GetKey("up") || Input.GetKey("w"))
        {            
            // clamping up
            if (curTurn + speed < maxRotation)
            {
                transform.Rotate(Vector3.forward * speed);
                curTurn += speed;
            }
            else if(curTurn + speed >= maxRotation)
            {
                transform.rotation = Quaternion.Euler(0, 0, maxRotation);
                curTurn = maxRotation;
            }
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {            
            // clamping up
            if (curTurn - speed > minRotation)
            {
                transform.Rotate(-Vector3.forward * speed);
                curTurn -= speed;
            }
            else if (curTurn - speed <= minRotation)
            {
                transform.rotation = Quaternion.Euler(0, 0, minRotation);
                curTurn = minRotation;
            }
        }
	}
}