using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {
	
	public void Play(string sceneName)
    {
        SceneManager.LoadScene(sceneName);      //Load scene with string
    }

    public void Play(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);    //Load scene with int
    }

    public void Quit()
    {
        Application.Quit();                     //Quits game
    }
}
