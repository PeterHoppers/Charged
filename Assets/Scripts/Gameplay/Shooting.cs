using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
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
	void Update ()
    {
        if (tag == "P1Gun" && Input.GetKeyDown("space") && DeathManager.p1CanShoot == true)
        {
            Shoot();
        }
        else if (tag == "P2Gun" && Input.GetKeyDown("return") && DeathManager.p2CanShoot == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(PlayerManager.numberOfPlayers == 1)
        {
            scoreManager.UpdateScore();
        }
        Rigidbody2D clone = Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        clone.velocity = transform.TransformDirection(Vector3.right * ControlScript.charge);
        clone.transform.SetParent(canvas.transform);
        clone.GetComponent<RectTransform>().localScale = new Vector3(.4f, .4f, .4f);

        switch(tag)
        {
            case "P1Gun":
                DeathManager.p1CanShoot = false;
                break;
            case "P2Gun":
                DeathManager.p2CanShoot = false;
                break;
        }
    }
}
