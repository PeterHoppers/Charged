using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEditorScript : MonoBehaviour {

    public void SetBackground(Image target)
    {
        target.sprite = GetComponent<Image>().sprite;
    }
}
