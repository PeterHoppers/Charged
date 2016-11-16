﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    ScoreManager scoreManager;
    RaceAgainstTime raceAgainstTime;

    Collider2D myCollider;

	// Use this for initialization
	void Start ()
    { 
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.enabled = true;
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        if(PlayerManager.numberOfPlayers == 2)
        {
            raceAgainstTime = GameObject.Find("GameManager").GetComponent<RaceAgainstTime>();
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (PlayerManager.numberOfPlayers == 1 && other.gameObject.tag == "PlayerOneProjectile")
        {
            Destroy(other.gameObject);
            scoreManager.LevelCompleted();
        }
        else if (other.gameObject.tag == "PlayerOneProjectile" || other.gameObject.tag == "PlayerTwoProjectile")
        {
            Destroy(other.gameObject);
            myCollider.enabled = false;
            raceAgainstTime.IncrementPoints(other.gameObject);
        }
    }
}
