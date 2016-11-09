﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{ 
    //Load the scene into the object then upon trigger, load next scene
    public string NextLevel;
	// Use this for initialization
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
