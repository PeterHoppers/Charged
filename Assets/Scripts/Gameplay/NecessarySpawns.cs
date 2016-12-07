using UnityEngine;
using System.Collections;

public class NecessarySpawns : MonoBehaviour {

    [Tooltip("The prefab or gameobject of the launcher")]
    public GameObject launcher;

    [Tooltip("The prefab or gameobject of the exit")]
    public GameObject exit;
    private GameObject inSceneLauncher;         // saves the launcher object
    private GameObject inSceneExit;             // saves the exit object

    private GameObject canvas;                  // grabs canvas to make sure the transform is in the correct spot
    private RectTransform startPoint;
    private RectTransform endPoint;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (canvas == null)
            Debug.LogError("The Canvas is not tagged or does not exist.");
    }
    public void ActivateObjects(GameObject background)
    {
        // If point exists, select it; otherwise, create the point;
        startPoint = (RectTransform)background.transform.FindChild("StartPoint");
        if (startPoint == null)
        {
            startPoint.anchorMin = new Vector2(0, 0.5f);
            startPoint.anchorMax = new Vector2(0, 0.5f);
            startPoint.localPosition = new Vector3(60, 0, 0);
        }
        // If point exists, select it; otherwise, create the point;
        endPoint = (RectTransform)background.transform.FindChild("EndPoint");
        if (endPoint == null)
        {
            endPoint.anchorMin = new Vector2(1, 0.5f);
            endPoint.anchorMax = new Vector2(1, 0.5f);
            endPoint.localPosition = new Vector3(-60, 0, 0);
        }

        if (inSceneLauncher != null)        //if it already exists, destory that previous object
            Destroy(inSceneLauncher);

        if (inSceneExit != null)
            Destroy(inSceneExit);

        // ========  Spawn Launcher ============
        inSceneLauncher = (GameObject) Instantiate(launcher, canvas.transform);
        inSceneLauncher.GetComponent<RectTransform>().localPosition = startPoint.localPosition;
        inSceneLauncher.transform.localScale = Vector3.one;
        
        // ======== Spawn Exit ================
        inSceneExit = (GameObject) Instantiate(exit, canvas.transform);
        inSceneExit.GetComponent<RectTransform>().localPosition = endPoint.localPosition;
        inSceneExit.transform.localScale = Vector3.one;
    }
}
