using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IonPlacement : MonoBehaviour {

    public GameObject positiveIonPrefab;
    public GameObject negativeIonPrefab;
    public Text positiveIonText;
    public Text negativeIonText;
    public float availablePositiveIons;
    float positiveIonsUsed;
    public float availableNegativeIons;
    float negativeIonsUsed;
    GameObject gameManager;
    LevelEditorScript levelEditor;
    List<GameObject> activeIons;
    GameObject tempIon;

	// Use this for initialization
	void Start () {
        activeIons = new List<GameObject>();
        gameManager = GameObject.Find("GameManager");

        if (gameManager == null)
            Debug.LogError("No GameManager found");

        levelEditor = gameManager.GetComponent<LevelEditorScript>();

        if (levelEditor == null)
            Debug.LogError("No level editor script found on the GameManager");

        if (positiveIonText == null)
            Debug.LogError("Give me the text box for positive ions used");
        else
            positiveIonText.text = "Positive ions used: " + positiveIonsUsed;

        if (positiveIonText == null)
            Debug.LogError("Give me the text box for positive ions used");
        else
            negativeIonText.text = "Negative ions used: " + negativeIonsUsed;

    }
	
	// Update is called once per frame
	void Update () {

        //Left click places positive ion
	    if(Input.GetMouseButtonUp(0))
        {
            if (availablePositiveIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(positiveIonPrefab, "Positive"));
                availablePositiveIons--;
                positiveIonsUsed++;
                positiveIonText.text = "Positive ions used: " + positiveIonsUsed;
                gameManager.GetComponent<ScoreManager>().UpdateScore(1);
            }
        }

        //Right click places negative ion
        if (Input.GetMouseButtonUp(1))
        {
            if (availableNegativeIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(negativeIonPrefab, "Negative"));
                availableNegativeIons--;
                negativeIonsUsed++;
                negativeIonText.text = "Negative ions used: " + negativeIonsUsed;
                gameManager.GetComponent<ScoreManager>().UpdateScore(1);
            }
        }

        //Escape checks to see if there are any ions active. If so, check the tag of the last one created, increment respective available ions, and destroy that ion
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (activeIons.Count > 0)
            {
                tempIon = activeIons[activeIons.Count - 1];
                if (tempIon.tag == "Positive")
                {
                    availablePositiveIons++;
                    positiveIonsUsed--;
                    positiveIonText.text = "Positive ions used: " + positiveIonsUsed;
                }
                else if (tempIon.tag == "Negative")
                {
                    availableNegativeIons++;
                    negativeIonsUsed--;
                    negativeIonText.text = "Negative ions used: " + negativeIonsUsed;
                }

                gameManager.GetComponent<ScoreManager>().UpdateScore(-1);
                Destroy(activeIons[activeIons.Count - 1]);
                activeIons.Remove(activeIons[activeIons.Count - 1]);
            }
        }
    }
}