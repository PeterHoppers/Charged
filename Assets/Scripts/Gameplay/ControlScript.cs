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
     [Header("Max Firepower")]
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
        if (transform.tag == "PlayerOne" && Input.GetKey("w"))
        {
            AimingUp();
        }
        else if (transform.tag == "PlayerTwo" && Input.GetKey("up"))        //Aiming up for both players
        {
            AimingUp();
        }
        ///////////////////////////////////////////////////////////////
        if (transform.tag == "PlayerOne" && Input.GetKey("s"))
        {
            AimingDown();
        }
        else if (transform.tag == "PlayerTwo" && Input.GetKey("down"))      //Aim down for both players
        {
            AimingDown();
        }
        ///////////////////////////////////////////////////////////////
        if (transform.tag == "PlayerOne" && Input.GetKey("d") && Time.time > wait + .002f)
        {
            ChargingUp();
        }
        else if(transform.tag == "PlayerTwo" && Input.GetKey("right") && Time.time > wait + .002f)      //charge up for both players
        {
            ChargingUp();
        }
        ///////////////////////////////////////////////////////////////
        if (transform.tag == "PlayerOne" && Input.GetKey("a") && Time.time > wait + .002f)
        {
            CoolingDown();
        }
        else if (transform.tag == "PlayerTwo" && Input.GetKey("left") && Time.time > wait + .002f)      //charge down for both players
        {
            CoolingDown();
        }
	}

    void AimingUp()
    {
        // clamping up
        if (curTurn + speed < maxRotation)
        {
            transform.Rotate(Vector3.forward * speed);
            curTurn += speed;
        }
        else if (curTurn + speed >= maxRotation)
        {
            transform.rotation = Quaternion.Euler(0, 0, maxRotation);
            curTurn = maxRotation;
        }
    }
    void AimingDown()
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
    void ChargingUp()
    {
        // charging up
        if (ControlScript.charge < maxCharge)
        {
            ControlScript.charge++;
            print("your charge is at: " + ControlScript.charge);
            wait = Time.time;
        }
    }
    void CoolingDown()
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