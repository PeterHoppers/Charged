using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    private GameObject canvas;

    //GameObject preplacedObj;
    [SerializeField]
    private Rigidbody2D myBullet;
    private ScoreManager scoreManager;
 
	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Canvas");
        if (canvas == null)
            Debug.LogError("No canvas found.");

        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        if (scoreManager == null)
            Debug.LogError("No ScoreManager script found on GameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (tag == "P1Gun" && Input.GetKeyDown("space") && DeathManager.canShoot == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        scoreManager.UpdateScore();

        // ============= Create bullet ================ 
        Rigidbody2D clone = Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
        clone.velocity = transform.TransformDirection(Vector3.right * ControlScript.charge);
        clone.transform.SetParent(canvas.transform);
        clone.GetComponent<RectTransform>().localScale = new Vector3(.4f, .4f, .4f);

        if (tag == "P1Gun") {
            DeathManager.canShoot = false;
        }
    }
}
