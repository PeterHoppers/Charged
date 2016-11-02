using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    ScoreManager scoreManager;
    //Load the scene into the object then upon trigger, load next scene
    public string NextLevel;

	// Use this for initialization
	void Start ()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            scoreManager.LevelCompleted();
        }
    }
}
