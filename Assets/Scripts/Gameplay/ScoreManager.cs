using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    [Tooltip("The canvas text object for the tries count.")]
    public Text triesText;
    int tries;                                  //Keeps track of the number of tries.
    public GameObject gameManager;
    public GameObject levelCompletedPanel;
    public GameObject nextLevelButton;
    [Header("Star Images")]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    int starsNeededToCont;
    public int oneStarAttempts;
    public int twoStarAttempts;
    public int threeStarAttempts;
    int starsEarned;
    public static bool canContinue = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
            Debug.LogError("No game manager found");

        if(PlayerManager.numberOfPlayers == 2)
        {
            enabled = false;
        }
        triesText.text = "Attempts: " + tries;      //Change the text at the start to make sure it says the correct text.S

        if (LevelSelect.staticStarsNeeded != null)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            starsNeededToCont = LevelSelect.staticStarsNeeded[scene];
        }
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
        print("Level completed called");
        if (gameManager != null)
            gameManager.GetComponent<IonPlacement>().enabled = false;

        levelCompletedPanel.SetActive(true);
        if (tries <= oneStarAttempts)
        {
            print("3 stars earned");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            starsEarned = 3;
        }
        else if (tries <= twoStarAttempts && tries >= oneStarAttempts)
        {
            print("2 stars earned");
            star1.SetActive(true);
            star2.SetActive(true);
            starsEarned = 2;
        }
        else if (tries <= threeStarAttempts && tries >= twoStarAttempts)
        {
            print("2 stars earned");
            star1.SetActive(true);
            starsEarned = 1;
        }

        StarCount.starCount += starsEarned;

        if (StarCount.starCount >= starsNeededToCont)                   // If enough earned, allow to continue
        {
            GameObject.Find("StarsNeeded").SetActive(false);
            canContinue = true;
            nextLevelButton.GetComponent<Button>().interactable = true;
        }
        else
        {                                                  // Otherwise, show amount needed to cont.
            GameObject.Find("StarsNeeded").GetComponent<Text>().text = "Stars Needed to Continue: " + (starsNeededToCont - StarCount.starCount);
            nextLevelButton.GetComponent<Button>().interactable = false;
        }
    }
}


