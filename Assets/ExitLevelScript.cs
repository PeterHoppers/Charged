//Chritopher J. Koester
//preschool homework assignment 101

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitLevelScript : MonoBehaviour {
    GameObject pauseMenu;
    GameObject doubleCheck;
    GameObject menu;
    GameObject myToggle;
    bool wasEnabled = false;//this bool checks to see if the ionplacement was already on. That way, we don't enable it if it wasn't
    //already enabled before the player paused the game


	// Use this for initialization
	void Start ()
    {
        //finding el menu
        pauseMenu = GameObject.Find("Canvas/PauseMenu/PauseBox");
        menu = GameObject.Find("Canvas/PauseMenu");
        doubleCheck = GameObject.Find("Canvas/PauseMenu/DoubleCheckBox");
        //find el taco.. I mean toggle
        myToggle = GameObject.Find("Canvas/ToggleIonPlacement");
        doubleCheck.SetActive(false);
        menu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //disabling and enabling the pause menu depending on whether or not it is active or false
        if (Input.GetKeyDown("escape"))
        {
            if (!menu.activeSelf)
            {//pausing game
                if (gameObject.GetComponent<IonPlacement>().enabled == true)
                {//recalling if the game object was last enabled
                    gameObject.GetComponent<IonPlacement>().enabled = false;
                    wasEnabled = true;
                }
                myToggle.SetActive (false);
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {//resuming game
                if (wasEnabled)
                {
                    gameObject.GetComponent<IonPlacement>().enabled = true;
                    wasEnabled = false;
                }
                myToggle.SetActive(true);
                menu.SetActive(false);
                Time.timeScale = 1;
            }
 
        }
	}

    public void DoubleCheck()
    {
        doubleCheck.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Cancel()
    {
        doubleCheck.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void MainMenu()
    {//returning to the menu
        Time.timeScale = 1;
        myToggle.SetActive(true);
        SceneManager.LoadScene("MainMenu");

    }

    public void Resume()
    {//resuming the game
        if (wasEnabled)
        {//recalling if the game object was last enabled
            gameObject.GetComponent<IonPlacement>().enabled = true;
            wasEnabled = false;
        }
        myToggle.SetActive(true);
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
