using UnityEngine;
using System.Collections;


public class GridSnapping : MonoBehaviour {

    [Tooltip("Object will snap to multiples of this number")]
    public float snapTo = 1;
    [Tooltip("When clicked, it will only snap on start. Else, it will snap on update as well")]
    public bool onlyStart = true;
    RectTransform currentTransfrom;

    // Use this for initialization
    void Start ()
    {
        if (GetComponent<RectTransform>() != null)
        {
            currentTransfrom = GetComponent<RectTransform>();
            snap();
        }
        else
        {
            Debug.LogError("There is no rect Transform attached to this object.");
        }
	}

    void snap()
    {
        float xPos = currentTransfrom.localPosition.x;
        float yPos = currentTransfrom.localPosition.y;
        xPos = findSnap(xPos);
        yPos = findSnap(yPos);
        currentTransfrom.localPosition = new Vector2(xPos, yPos);
    }

    float findSnap(float number)
    {
        if (snapTo == 0) return number;         //cannot divide by 0

        number = (number * (1 / snapTo));       //math equation to
        number = Mathf.Round(number);           //round to nearest number
        number = (number / (1 / snapTo));       //that is a multiple of snapTo
        return number;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!onlyStart)
        {
            snap();
        }
	}
}
