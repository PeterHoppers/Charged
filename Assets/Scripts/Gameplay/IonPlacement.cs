using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IonPlacement : MonoBehaviour {

    public GameObject positiveIonPrefab;
    public GameObject negativeIonPrefab;
    public float availablePositiveIons;
    public float availableNegativeIons;
    [HideInInspector]
    public static int numberOfNegatives;
    [HideInInspector]
    public static int numberOfPositives;

    GameObject gameManager;
    LevelEditorScript levelEditor;
    List<GameObject> activeIons;
    GameObject tempIon;
    public IonTrackerScript ionTracker;

	// Use this for initialization
	void Start ()
    {//encontrar el gameobject y obtener la secuencia de comandos -Cristóbal
        ionTracker = GameObject.Find("Canvas/ionTracker").GetComponent<IonTrackerScript>();

        activeIons = new List<GameObject>();
        gameManager = GameObject.Find("GameManager");

        if (gameManager == null)
            Debug.LogError("No GameManager found");

        levelEditor = gameManager.GetComponent<LevelEditorScript>();

        if (levelEditor == null)
            Debug.LogError("No level editor script found on the GameManager");

        //starting the ions at 0 or else the ion values would leave off where they last left (because they are static)
        numberOfNegatives = 0;
        numberOfPositives = 0;
    }
	
	// Update is called once per frame
	void Update () {

        //Left click places positive ion
	    if(Input.GetMouseButtonUp(0))
        {
            if (availablePositiveIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(positiveIonPrefab));
                availablePositiveIons--;
                numberOfPositives++;
                ionTracker.ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
            }
        }

        //Right click places negative ion
        if (Input.GetMouseButtonUp(1))
        {
            if (availableNegativeIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(negativeIonPrefab));
                availableNegativeIons--;
                numberOfNegatives++;
                ionTracker.ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
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
                    numberOfPositives--; //changing potential score due to removal of ion
                }
                else if (tempIon.tag == "Negative")
                {
                    availableNegativeIons++;
                    numberOfNegatives--; //changing potential score due to removal of ion
                }
                
                Destroy(activeIons[activeIons.Count - 1]);
                activeIons.Remove(activeIons[activeIons.Count - 1]);
                ionTracker.ScoreTracker(); //Refrescante la puntuación en el IonTrackerScript
            }
        }
    }
}