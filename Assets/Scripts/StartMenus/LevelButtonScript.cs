using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    [HideInInspector]
    public int starsNeeded;
    [HideInInspector]
    public int myLevel;

    private float doubleClick;

    public void PlayLevel()
    {
        //  checking to see if the level image was double clicked
        if (doubleClick <= Time.time)
            doubleClick = Time.time + .2f;
        else
        {
            // if so, play scene level, if star count is high enough
            if (StarCount.starCount >= starsNeeded) {
                SceneManager.LoadScene(myLevel);
            }
        }
    }
}