using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEditorScript : MonoBehaviour {
    public static GameObject background;
    static GameObject levelBackground;
    public GameObject backgroundPrefab;

    void Start()
    {
        FindBackground();
    }

    public void SetBackground(Image target)
    {
        Destroy(target);
        background = backgroundPrefab;
        GameObject clone = Instantiate(background, GameObject.Find("BackgroundContainer").transform) as GameObject;
        clone.name = "Background";
        clone.GetComponent<RectTransform>().localPosition = Vector3.zero;
        clone.GetComponent<RectTransform>().localScale = Vector3.one;
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
    }

    void FindBackground()
    {
        levelBackground = GameObject.Find("Background");
        if (!levelBackground)
            Debug.LogError("No level image componenet was found");
    }
}