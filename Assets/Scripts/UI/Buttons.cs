using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public static int nextLevel = 2;
    public void NextLevel()
    {
        
        //This will require a sceneManager.
        SceneManager.LoadScene(nextLevel);
        nextLevel++;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
