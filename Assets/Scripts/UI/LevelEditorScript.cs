using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEditorScript : MonoBehaviour {

    public static Sprite backgroundSprite;
    Image levelBackground;

    void Start()
    {
        levelBackground = GameObject.Find("LevelImage").GetComponent<Image>();
        if (!levelBackground)
            Debug.LogError("No level image componenet was found");
    }

    public void SetBackground(Image target)
    {
        backgroundSprite = GetComponent<Image>().sprite;
        target.sprite = backgroundSprite;
    }

    public void SetBackground()
    {
        backgroundSprite = GetComponent<Image>().sprite;
        levelBackground.sprite = backgroundSprite;
    }
}