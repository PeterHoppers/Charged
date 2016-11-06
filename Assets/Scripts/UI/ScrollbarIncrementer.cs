using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarIncrementer : MonoBehaviour
{
    public RectTransform content;
    bool scrolling;
    float stepAmount;
    float timer;
    Vector3 nextPos;

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