using UnityEngine;
using System.Collections;


public class GridSnapping : MonoBehaviour {

    RectTransform currentTransfrom;
    GridManager gridSystem;

    // Use this for initialization
    void Start ()
    {
        gridSystem = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GridManager>();

        if (GetComponent<RectTransform>() != null)
        {
            currentTransfrom = GetComponent<RectTransform>();
            currentTransfrom.localPosition = gridSystem.snap(currentTransfrom.localPosition);
        }
        else
        {
            Debug.LogError("There is no rect Transform attached to this object.");
        }
	}

    
	
	// Update is called once per frame
	void Update ()
    {
        if (!gridSystem.onlyStart)
        {
            currentTransfrom.localPosition = gridSystem.snap(currentTransfrom.localPosition);
        }
	}
}
