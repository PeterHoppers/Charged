using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IonPlacement : MonoBehaviour {

    public GameObject positiveIonPrefab;
    public GameObject negativeIonPrefab;
    public float availablePositiveIons;
    public float availableNegativeIons;
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
            }
        }

        //Right click places negative ion
        if (Input.GetMouseButtonUp(1))
        {
            if (availableNegativeIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(negativeIonPrefab));
                availableNegativeIons--;
            }
        }

        //Escape checks to see if there are any ions active. If so, check the tag of the last one created, increment respective available ions, and destroy that ion
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (activeIons.Count > 0)
            {
                tempIon = activeIons[activeIons.Count - 1];
                if(tempIon.tag == "Positive")
                    availablePositiveIons++;
                else if(tempIon.tag == "Negative")
                    availableNegativeIons++;
                
                Destroy(activeIons[activeIons.Count - 1]);
                activeIons.Remove(activeIons[activeIons.Count - 1]);
            }
        }
    }
}