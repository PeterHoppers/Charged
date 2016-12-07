// Cristopher
// CSG
// Nov 2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IonTrackerScript : MonoBehaviour {
    private Text negatives;
    private Text positives;
    private Text score;

    [HideInInspector]
    public int points;
    private ScoreManager myScore;
    private IonPlacement myIons;

    // Use for initialization
    public void Start ()
    {
        myIons = GameObject.Find("GameManager").GetComponent<IonPlacement>();
        if (myIons == null)
            Debug.LogError("No IonPlacement script found on GameManager");

        // Find all the text components
        negatives = GameObject.Find("Canvas/IonTrackers/Negatives").GetComponent<Text>();
        if (negatives == null) 
            Debug.LogError(" No Negative text component found on IonTrackers on the canvas");

        positives = GameObject.Find("Canvas/IonTrackers/Positives").GetComponent<Text>();
        if (positives == null)
            Debug.LogError(" No Positive text component found on IonTrackers on the canvas");

        // The player can place Ions
        if (myIons.cannotPlaceNegative)
            negatives.gameObject.SetActive(false);

        if (myIons.cannotPlacePositive)
            positives.gameObject.SetActive(false);

        // Find score and score text
        myScore = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        if (myScore == null)
            Debug.LogError("No ScoreManager script found on GameManager");

        score = myScore.levelCompletedPanel.transform.FindChild("Score").GetComponent<Text>();
        if (score == null)
            Debug.LogError("No Score text component found on the Level Completed Panel");
    }

    public void ScoreTracker ()
    {
        // Assign the count / score
        negatives.text = "Negatives Ions: " + IonPlacement.activeNegativeIons.Count;
        positives.text = "Positives Ions: " + IonPlacement.activePositiveIons.Count;
        score.text = "Points: " + points.ToString();
    }
}
