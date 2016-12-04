using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialText : MonoBehaviour {

    public KeyCode[] keys;
    public float delay;
    Text text;
    double aplpha = 0;
    bool beginIntro;
    bool startIntro;
    bool endIntro;
    // Use this for initialization
    void Start ()
    {
        text = GetComponent<Text>();
        text.color = new Color32(255, 255, 255, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!DeathManager.isFinished)
        {
            if (!beginIntro)
            {
                StartCoroutine(FadeIn());
            }

            if (startIntro)
            {
                if (aplpha <= 252)
                {
                    aplpha += 2;
                    text.color = new Color32(255, 255, 255, (byte)aplpha);
                }
                else
                {
                    aplpha = 255;
                    startIntro = false;
                    endIntro = true;
                }
            }

            if (endIntro)
            {
                foreach (KeyCode key in keys)
                {
                    if (Input.GetKey(key))
                    {
                        aplpha = 255;
                    }
                    else
                    {
                        if (aplpha > 80)
                        {
                            aplpha = aplpha - .5;
                        }
                    }
                }

                if (keys.Length == 0)
                {
                    if (aplpha > 80)
                    {
                        aplpha = aplpha - .5;
                    }
                }

                text.color = new Color32(255, 255, 255, (byte)aplpha);
            }
        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(delay);
        startIntro = true;
        beginIntro = true;
    }
}
