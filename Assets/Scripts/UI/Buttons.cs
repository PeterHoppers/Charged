using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void NextLevel()
    {
        BasicUtilities.NextLevel();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
