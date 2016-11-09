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
     [Header("Minimum Firepower")]
    public int maxCharge = 500;
    [HideInInspector]
    public static float charge = 100f;
    float wait;
    float curTurn = 0;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
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

        if ((Input.GetKey("right") || Input.GetKey("a")) && Time.time > wait + .002f)
        {
            print(maxCharge);
            // charging up
            if (ControlScript.charge < maxCharge)
            {
                ControlScript.charge++;
                print("your charge is at: " + ControlScript.charge);
                wait = Time.time;
            }
        }
        if ((Input.GetKey("left") || Input.GetKey("s")) && Time.time > wait + .002f)
        {
            
            // cooling down
            if (ControlScript.charge > 0)
            {
                ControlScript.charge--;
                print("your charge is at: " + ControlScript.charge);
                wait = Time.time;
            }
        }
	}
}
//for (int i = 0; i < myIndex % myActive.Length; i++)