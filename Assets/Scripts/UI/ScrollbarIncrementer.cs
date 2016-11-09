using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarIncrementer : MonoBehaviour
{
    public RectTransform content;
    public GameObject buttonPrefab;
    public List<GameObject> backgroundPrefabs;
    bool scrolling;
    float stepAmount;
    float timer;
    Vector3 nextPos;
    float xPos;

    void Start()
    {
        for (int i = 0; i < backgroundPrefabs.Count; i++)
        {
            GameObject clone = Instantiate(buttonPrefab, content.transform) as GameObject;
            clone.GetComponent<RectTransform>().localPosition = new Vector3(xPos, 0, 0);
            clone.GetComponent<RectTransform>().localScale = Vector3.one;
            clone.GetComponent<Image>().sprite = backgroundPrefabs[i].GetComponent<Image>().sprite;
            clone.GetComponent<LevelEditorScript>().backgroundPrefab = backgroundPrefabs[i];
        }
    }

    void Update()
    {
        if (timer >= .6f)
        {
            StopAllCoroutines();
            timer = 0;
            scrolling = false;
        }
    }

    public void Step(float aStepAmount)
    {
        stepAmount = aStepAmount;        
        StartCoroutine(ScrollCoroutine());
    }

    IEnumerator ScrollCoroutine()
    {
        if(!scrolling)
        {
            scrolling = true;
            nextPos = new Vector3(content.position.x + stepAmount, content.position.y, content.position.z);
            yield return new WaitUntil(Scroll);
            timer = 0;
            scrolling = false;
        }
    }

    bool Scroll()
    {
        timer += 1 / 60.0f;
        content.position = Vector3.Lerp(content.position, nextPos, Time.deltaTime * 3);

        if (Vector3.Distance(content.position, nextPos) <= 1f)
            return true;
        else
            return false;
    }
}