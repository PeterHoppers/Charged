using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public int capacity = 100;
    public float fireRate =0;
    float wait;
    public bool isActive;

    GameObject canvas;
    [SerializeField]
    Rigidbody2D myBullet;
    ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && !isActive)
        {
            isActive = true;
            scoreManager.UpdateScore();
            Rigidbody2D clone = Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
            clone.transform.SetParent(canvas.transform);
            clone.velocity = transform.TransformDirection(Vector3.right * Power.thePower);
            //clone.AddForce(clone.transform.forward * ControlScript.charge);
        }
	}

    public void ChangeBool()        //Called from reset to set the bullet back to false
    {
        isActive = false;
    }
}
