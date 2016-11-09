using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Tooltip("The canvas text object for the tries count.")]
    public Text triesText;
    int tries;                                  //Keeps track of the number of tries.
    void Start()
    {
        triesText.text = "Tries " + tries;      //Change the text at the start to make sure it says the correct text.
    }
    public void UpdateScore()
    {
        tries++;                                //Updates the try count
        triesText.text = "Tries " + tries;
    }
    public void ResetScore()
    {
        tries = 0;
        triesText.text = "Tries " + tries;      //Resets the try count
    }
}
