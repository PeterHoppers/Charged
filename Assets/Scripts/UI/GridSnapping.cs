using UnityEngine;
using System.Collections;


public class GridSnapping : MonoBehaviour {

    public float snapTo = 1;
    public bool onlyStart = true;
    RectTransform currentTransfrom;

    // Use this for initialization
    void Start ()
    {
        if (GetComponent<RectTransform>() != null)
        {
           currentTransfrom = GetComponent<RectTransform>();
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
        if (snapTo == 0) return number;

        number = (number * (1 / snapTo));
        number = Mathf.Round(number);
        number = (number / (1 / snapTo));
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
