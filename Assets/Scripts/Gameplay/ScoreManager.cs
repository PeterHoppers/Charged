using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public bool disableScore = false;
    [Tooltip("The canvas text object for the tries count.")]
    public Text triesText;
    [HideInInspector]//Hice pública Esto! fue modificado por Cristóbal así puedo obtener esta información desde otro script
    public int tries;                                  //Keeps track of the number of tries.
    [HideInInspector]
    public GameObject gameManager;
    public GameObject levelCompletedPanel;
    public GameObject nextLevelButton;
    [Header("Star Images")]
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int oneStarScore;
    public int twoStarScore;
    public int threeStarScore;
    int starsEarned;
    int starsNeededToCont;
    public static bool canContinue = false;
    IonTrackerScript ionTracker; //getting the script
    IonPlacement ionPlacement; //getting the script

    void Start()
    {
        ionPlacement = GameObject.Find("GameManager").GetComponent<IonPlacement>();
        gameManager = GameObject.Find("GameManager");
        if (gameManager == null)
            Debug.LogError("No game manager found");

        ionTracker = gameManager.GetComponent<IonTrackerScript>();

        if (PlayerManager.numberOfPlayers == 2)
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
        ionTracker.ScoreTracker(); //Refrescante la puntuación en el gameManagerScript
    }
    public void ResetScore()
    {
        tries = 0;
        triesText.text = "Attempts: " + tries;      //Resets the try count
        ionTracker.ScoreTracker(); //Refrescante la puntuación en el gameManagerScript
    }
    public void LevelCompleted()
    {
        gameManager.GetComponent<IonPlacement>().enabled = false;
        levelCompletedPanel.SetActive(true);

        if (!disableScore)
        {
            //======================Calculate Score=================================
            ionTracker.points += 100 + (((int)ionPlacement.availablePositiveIons + (int)ionPlacement.availableNegativeIons) * 25) - (((int)IonPlacement.activePositiveIons.Count + (int)IonPlacement.activeNegativeIons.Count) * 25);
            ionTracker.ScoreTracker();
            //using this temp variable as a means to compare the actual score to a percentage of to its max (otherwise the statement would, again, be long)
            float temp = 100 + (((int)ionPlacement.availablePositiveIons + (int)ionPlacement.availableNegativeIons) * 25);

            //========================Show the Stars Earned===========================
            if (ionTracker.points >= threeStarScore)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                starsEarned = 3;
            }
            else if (ionTracker.points < threeStarScore && ionTracker.points >= twoStarScore)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                starsEarned = 2;
            }
            else if (ionTracker.points < twoStarScore && ionTracker.points >= oneStarScore)
            {
                star1.SetActive(true);
                starsEarned = 1;
            }

            StarCount.starCount += starsEarned;

            //=================Stars Needed To Continue=================================
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
}


