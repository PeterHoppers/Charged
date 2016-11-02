using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void NextLevel()
    {
        //This will require a sceneManager.
        //SceneManager.LoadScene();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
