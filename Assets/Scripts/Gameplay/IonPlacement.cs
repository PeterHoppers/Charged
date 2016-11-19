using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IonPlacement : MonoBehaviour {

    public GameObject positiveIonPrefab;
    public GameObject negativeIonPrefab;
    public float availablePositiveIons;
    public float availableNegativeIons;
    float doubleClick = 0;
    GameObject gameManager;
    LevelEditorScript levelEditor;
    List<GameObject> activeIons;

	// Use this for initialization
	void Start ()
    {
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
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == "Positive")
                {
                    if (Input.GetKey(KeyCode.Delete))
                    {
                        DeleteIon(hitInfo.collider.gameObject);
                        return;
                    }
                }
            }

            if (availablePositiveIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(positiveIonPrefab, "Positive"));
                availablePositiveIons--;
            }
        }

        //Right click places negative ion
        if (Input.GetMouseButtonUp(1))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == "Negative")
                {
                    if (Input.GetKey(KeyCode.Delete))
                    {
                        DeleteIon(hitInfo.collider.gameObject);
                        return;
                    }
                }
            }

            if (availableNegativeIons > 0)
            {
                activeIons.Add(levelEditor.CreateNewObjectAtCursor(negativeIonPrefab, "Negative"));
                availableNegativeIons--;
            }
        }

        //Escape checks to see if there are any ions active. If so, check the tag of the last one created, increment respective available ions, and destroy that ion
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (activeIons.Count > 0)
            {
                GameObject tempIon = activeIons[activeIons.Count - 1];
                DeleteIon(tempIon);
            }
        }
    }

    void DeleteIon(GameObject tempIon)
    {
        if (tempIon.tag == "Positive")
            availablePositiveIons++;
        else if (tempIon.tag == "Negative")
            availableNegativeIons++;

        int index = activeIons.IndexOf(tempIon);
        Destroy(activeIons[index]);
        activeIons.Remove(activeIons[index]);
    }
}