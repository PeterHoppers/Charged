using UnityEngine;
using System.Collections;

public class Resize : MonoBehaviour {

    public float sizingFactor = 0.2f;     // Manipulate to satisfy difference between cursor and sizing

    private bool toResize = false;
    private bool drawing = false;
    private GameObject selectedObj;
    private Vector3 originalSize;
    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update() {
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.tag == "Unit" && Input.GetMouseButtonDown(0))  // If the object is selected
            {
                selectedObj = hit.transform.gameObject;
                originalSize = selectedObj.transform.localScale;
                toResize = true;                                            // Resize it
            }
        }

        // check if we want to start, end, or continue drawing
        if (toResize) {
            if (Input.GetMouseButtonDown(0)) {
                drawing = true;
            }
                else if (Input.GetMouseButtonUp(0)) {
                    endDraw();
            }
                    else if (drawing) {
                        whileDrawing(selectedObj, originalSize);
            }
        }
    }

    void endDraw()
    {
        // forbid the Update to call whileDrawing()
        drawing = false;
        toResize = false;
    }

    void whileDrawing(GameObject selectedObj, Vector3 originalSize)
    {
        // manipulate the instance in whatever way you like
        Vector3 difference = selectedObj.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Find the difference between each coord
        float distanceInX = Mathf.Abs(difference.x);
        float distanceInY = Mathf.Abs(difference.y);

        // Don't allow to go negative, and keep it to integers
        if (distanceInX >= 1 && distanceInY >= 1)
        {
            selectedObj.transform.localScale = new Vector3(Mathf.Round(distanceInX) * sizingFactor, Mathf.Round(distanceInY) * sizingFactor, originalSize.z);
        }
    }
}
