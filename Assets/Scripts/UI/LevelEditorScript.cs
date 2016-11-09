using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEditorScript : MonoBehaviour {
    public static GameObject background;
    static GameObject levelBackground;
    public GameObject backgroundPrefab;
    GameObject folder;


    NecessarySpawns necessarySpawns;
    void Start()
    {
        necessarySpawns = GameObject.Find("GameManager").GetComponent<NecessarySpawns>();
        folder = GameObject.Find("CloneFolder");

        if (folder == null)
        {
            Debug.LogError("There is not an object called \"CloneFolder\"");
        }
    }

    public void SetBackground()
    {
        Destroy(levelBackground);
        background = backgroundPrefab;
        GameObject clone = Instantiate(background, GameObject.Find("BackgroundContainer").transform) as GameObject;
        clone.name = "Background";
        clone.GetComponent<RectTransform>().localPosition = Vector3.zero;
        clone.GetComponent<RectTransform>().localScale = Vector3.one;
        levelBackground = clone;
        necessarySpawns.ActivateObjects(background);
    }

    void FindBackground()
    {
        levelBackground = GameObject.Find("Background");
        if (!levelBackground)
            Debug.LogError("No level image componenet was found");
    }

    public void CreateNewObject()
    {
        GameObject clone = Instantiate(gameObject, folder.transform) as GameObject;
        clone.AddComponent<Draggable>();                                     //allows for dragging
        clone.AddComponent<GridSnapping>();                                 //allows for grid snapping
        clone.tag = "Clone";                    
        clone.GetComponent<Button>().enabled = false;                       //prevent it from being clicked
        clone.GetComponent<RectTransform>().localPosition = Vector2.zero;   //spawns in the middle
        BoxCollider2D boxC = clone.AddComponent<BoxCollider2D>();           //adds a collider for trash
        boxC.isTrigger = true;                                              
        boxC.size = new Vector2(100, 100);

    }
}