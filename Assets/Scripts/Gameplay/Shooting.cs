using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    GameObject canvas;
    [SerializeField]
    Rigidbody2D myBullet;

	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && DeathManager.canShoot == true)
        {
            Rigidbody2D clone = Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            clone.velocity = transform.TransformDirection(Vector3.right * ControlScript.charge);
            clone.transform.SetParent(canvas.transform);
            DeathManager.canShoot = false;
        }
	}
}
