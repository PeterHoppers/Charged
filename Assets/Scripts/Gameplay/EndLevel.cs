using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    ScoreManager scoreManager;
    GameObject gameManager;
    Collider2D myCollider;

	// Use this for initialization
	void Start ()
    { 
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = true;

        gameManager = GameObject.Find("GameManager");
        if (gameManager == null) {
            Debug.LogError("No Game Manager Found.");
        }

        scoreManager = gameManager.GetComponent<ScoreManager>();
        if (scoreManager == null) {
            Debug.LogError("No Score Manager found on Game Manager");
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerOneProjectile")                  // When the projectile hits the end point, end the level.
        {
            Destroy(other.gameObject);
            scoreManager.LevelCompleted();
            gameManager.GetComponent<ExitLevelScript>().enabled = false;
            DeathManager.isFinished = true;                                 // Level is finished
        }
    }
}
