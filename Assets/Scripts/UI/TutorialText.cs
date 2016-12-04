using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialText : MonoBehaviour {

    public KeyCode[] keys;
    public float delay;
    Text text;
    double aplpha = 255;
    // Use this for initialization
    void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (BasicUtilities.onlyOnce("FadeIn"))
        {
            StartCoroutine(FadeIn());
        }
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
            {
                print("pressed " + key);
                aplpha = 255;
            }
            else
            {
                aplpha = aplpha - .5;
            }
        }

        text.color = new Color32(255, 255, 255, (byte) aplpha);
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(delay);
    }
}
