using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [Tooltip("The canvas text object for the tries count.")]
    public Text triesText;
    int tries;                                  //Keeps track of the number of tries.
    public GameObject levelCompletedPanel;
    [Header("Star Images")]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int oneStarAttempts;
    public int twoStarAttempts;
    public int threeStarAttempts;
    int starsEarned;
    void Start()
    {
        triesText.text = "Attempts: " + tries;      //Change the text at the start to make sure it says the correct text.
    }
    public void UpdateScore()
    {
        tries++;                                //Updates the try count
        triesText.text = "Attempts: " + tries;
    }
    public void ResetScore()
    {
        tries = 0;
        triesText.text = "Attempts: " + tries;      //Resets the try count
    }
    public void LevelCompleted()
    {
        levelCompletedPanel.SetActive(true);
        if (tries <= oneStarAttempts)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            starsEarned = 3;
        }
        else if (tries <= twoStarAttempts && tries >= oneStarAttempts)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            starsEarned = 2;
        }
        else if (tries <= threeStarAttempts && tries >= twoStarAttempts)
        {
            star1.SetActive(true);
            starsEarned = 1;
        }
        StarCount.starCount += starsEarned;
    }
}


