using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    ScoreManager scoreManager;

	// Use this for initialization
	void Start ()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerOneProjectile" || other.gameObject.tag == "PlayerTwoProjectile")
        {
            Destroy(other.gameObject);
            if(PlayerManager.numberOfPlayers == 1)
            {
                scoreManager.LevelCompleted();
            }
        }
    }
}
