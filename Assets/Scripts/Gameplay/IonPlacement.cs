using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IonPlacement : MonoBehaviour {

    public GameObject positiveIonPrefab;
    public GameObject negativeIonPrefab;
    public int availablePositiveIons = 5;
    public int availableNegativeIons = 5;
    GameObject gameManager;
    LevelEditorScript levelEditor;
    List<GameObject> activePositiveIons;
    List<GameObject> activeNegativeIons;
    bool lastWasPositive = false;

    // Use this for initialization
    void Start ()
    {
        activePositiveIons = new List<GameObject>();
        activeNegativeIons = new List<GameObject>();
        gameManager = GameObject.Find("GameManager");

        if (gameManager == null)
            Debug.LogError("No GameManager found");

        levelEditor = gameManager.GetComponent<LevelEditorScript>();

        if (levelEditor == null)
            Debug.LogError("No level editor script found on the GameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Left click places positive ion
	    if(Input.GetMouseButtonUp(0))
        {
            if (Input.GetKey(KeyCode.Delete))
            {
                //==============If you are holding down delete, delete the nearest one============
                if (activePositiveIons.Count > 0)
                {
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = 100.0f;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                    GameObject closest = BasicUtilities.findNearest(mousePosition, activePositiveIons);
                    DeletePositiveIon(closest);

                }
            }

            if (availablePositiveIons > 0)
            {
                //==============If you are not holding delete, place one=============
                if (!Input.GetKey(KeyCode.Delete))
                {
                    activePositiveIons.Add(levelEditor.CreateNewObjectAtCursor(positiveIonPrefab, "Positive"));
                    lastWasPositive = true;
                    availablePositiveIons--;
                }
                
            }
        }

        //Right click places negative ion
        if (Input.GetMouseButtonUp(1))
        {
            if (activeNegativeIons.Count > 0)
            {
                //==============If you are holding down delete, delete the nearest one============
                if (Input.GetKey(KeyCode.Delete))
                {
                    Vector3 mousePosition = Input.mousePosition;
                    mousePosition.z = 100.0f;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

                    GameObject closest = BasicUtilities.findNearest(mousePosition, activeNegativeIons);
                    DeleteNegativeIon(closest);
                }
            }


            if (availableNegativeIons > 0)
            {
                //==============If you are not holding delete, place one=============
                if (!Input.GetKey(KeyCode.Delete))
                {
                    activeNegativeIons.Add(levelEditor.CreateNewObjectAtCursor(negativeIonPrefab, "Negative"));
                    lastWasPositive = false;
                    availableNegativeIons--;
                }
            }
        }

        //Escape checks to see if there are any ions active. If so, check the tag of the last one created, increment respective available ions, and destroy that ion
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (lastWasPositive)
            {
                DeletePositiveIon(activePositiveIons[(activePositiveIons.Count - 1)]);
            }
            else
            {
                if (activeNegativeIons.Count > 0)
                {
                    DeleteNegativeIon(activeNegativeIons[(activeNegativeIons.Count - 1)]);
                }
            }
        }
    }

    //==============Delete All Ions=================
    public void DeleteAll()
    {
        for (int index = 0; index < activePositiveIons.Count; index++)
        {
            DeletePositiveIon(activePositiveIons[index]);
        }

        for (int index = 0; index < activeNegativeIons.Count; index++)
        {
            DeleteNegativeIon(activeNegativeIons[index]);
        }
    }

    //=============Delete a positive ion===========
    void DeletePositiveIon(GameObject tempIon)
    {
        availablePositiveIons++;

        int index = activePositiveIons.IndexOf(tempIon);
        Destroy(activePositiveIons[index]);
        activePositiveIons.Remove(activePositiveIons[index]);
    }

    //============Delete a negative ion===========
    void DeleteNegativeIon(GameObject tempIon)
    {
        availableNegativeIons++;

        int index = activeNegativeIons.IndexOf(tempIon);
        Destroy(activeNegativeIons[index]);
        activeNegativeIons.Remove(activeNegativeIons[index]);
    }



}