using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public int capacity = 100;
    public float fireRate =0;
    float wait;


    [SerializeField]
    Rigidbody myBullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && capacity > 0 && Time.time > wait)
        {
            capacity -= 1;
            wait = Time.time + fireRate;
            Rigidbody clone = Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
            clone.velocity = transform.TransformDirection(Vector3.right * ControlScript.charge);
            //clone.AddForce(clone.transform.forward * ControlScript.charge);
        }
	}
}
