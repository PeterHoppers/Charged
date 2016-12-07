using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject playerOne;                    //Player One prefab
    [HideInInspector]
    public GameObject playerClone;             
    private GameObject canvas;
    private GameObject startPoint;                  //Where the player will spawn

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        if (canvas == null) 
            Debug.LogError("No canvas found");

        startPoint = GameObject.Find("StartPoint");
        if (startPoint == null)
            Debug.LogError("No Start Point found");

        ControlScript.startRotation = (int)startPoint.GetComponent<RectTransform>().eulerAngles.z;

        // ==================== Create the player when the level begins ===============================
        playerClone = Instantiate(playerOne, startPoint.transform.position, startPoint.transform.rotation) as GameObject;
        playerClone.transform.SetParent(canvas.transform);
        playerClone.GetComponent<RectTransform>().localScale = Vector3.one;
        playerClone.transform.tag = "Player";
    }
}
