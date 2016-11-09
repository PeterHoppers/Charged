using UnityEngine;
using System.Collections;

public class IonPlacement : MonoBehaviour {

    public float availiblePositiveIons;
    public float availibleNegativeIons;
    GameObject gameManager;
    LevelEditorScript levelEditor;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");

        if (gameManager == null)
            Debug.LogError("No GameManager found");

        levelEditor = gameManager.GetComponent<LevelEditorScript>();

        if (levelEditor == null)
            Debug.LogError("No level editor script found on the GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonUp(0))
        {
            if (availiblePositiveIons > 0)
            {
                levelEditor.CreateNewObjectAtCursor();
                availiblePositiveIons--;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (availibleNegativeIons > 0)
            {
                levelEditor.CreateNewObjectAtCursor();
                availibleNegativeIons--;
            }
        }
    }
}
