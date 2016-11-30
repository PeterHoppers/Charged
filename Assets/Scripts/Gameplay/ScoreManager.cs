using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
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
    int starsNeededToCont;
    public int oneStarScore;
    public int twoStarScore;
    public int threeStarScore;
    int starsEarned;
    public static bool canContinue = false;
    public IonTrackerScript ionTracker; //getting the script
    public IonPlacement ionPlacement; //getting the script

    void Start()
    {
        ionTracker = GameObject.Find("Canvas/IonTrackers").GetComponent<IonTrackerScript>();
        ionPlacement = GameObject.Find("GameManager").GetComponent<IonPlacement>();
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
        ionTracker.ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
    }
    public void ResetScore()
    {
        tries = 0;
        triesText.text = "Attempts: " + tries;      //Resets the try count
        ionTracker.ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
    }
    public void LevelCompleted()
    {
        ionTracker.points += 100 + (((int)ionPlacement.availablePositiveIons + (int)ionPlacement.availableNegativeIons) * 25) - (((int)IonPlacement.numberOfPositives + (int)IonPlacement.numberOfNegatives) * 25);
        ionTracker.ScoreTracker();
        //using this temp variable as a means to compare the actual score to a percentage of to its max (otherwise the statement would, again, be long)
        float temp = 100 + (((int)ionPlacement.availablePositiveIons + (int)ionPlacement.availableNegativeIons) * 25);
        print("Level completed called");
        if (gameManager != null)
            gameManager.GetComponent<IonPlacement>().enabled = false;

        levelCompletedPanel.SetActive(true);
        if (ionTracker.points >= threeStarScore)
        {
            print("3 stars earned");
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            starsEarned = 3;
        }
        else if (ionTracker.points < threeStarScore && ionTracker.points >= twoStarScore)
        {
            print("2 stars earned");
            star1.SetActive(true);
            star2.SetActive(true);
            starsEarned = 2;
        }
        else if (ionTracker.points < twoStarScore && ionTracker.points >= oneStarScore)
        {
            print("1 stars earned");
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


