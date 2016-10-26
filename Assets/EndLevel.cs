using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    //Grab the PlayerGo using the tag in the Start()
    GameObject playerGO;

    //Load the scene into the object then upon trigger, load next scene
    public Scene NextLevel;

	// Use this for initialization
	void Start ()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerGO)
        {
            SceneManager.LoadScene(NextLevel.ToString());
        }
    }
}
