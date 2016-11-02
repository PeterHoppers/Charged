using UnityEngine;
using System.Collections;

public class ToggleBar : MonoBehaviour {

    bool isClosed = false;
    GameObject bar;
    Animator animBar;
    Vector3 startPosition;
    Vector2 emptyPosition;
    RectTransform barTransform;

    bool runningCloorsLight;

    void Start()
    {
        bar = transform.parent.gameObject;
        animBar = bar.GetComponent<Animator>();

        emptyPosition = GameObject.FindGameObjectWithTag("Empty").GetComponent<RectTransform>().anchoredPosition;
        barTransform = bar.GetComponent<RectTransform>();
        startPosition = barTransform.anchoredPosition;
    }

    public void toggleBar()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        if (!runningCloorsLight)
        {
            runningCloorsLight = true;

            if (isClosed)
            {
                animBar.Play("maximize");
                yield return new WaitUntil(LerpDown);
            }
            else
            {
                animBar.Play("minimize");
                yield return new WaitUntil(LerpUp);
            }

            isClosed = !isClosed;
            runningCloorsLight = false;
        }
    }

    bool LerpUp()
    {
        barTransform.anchoredPosition = Vector3.Lerp(barTransform.anchoredPosition, emptyPosition, Time.deltaTime * 4f);

        if (Vector3.Distance(barTransform.anchoredPosition, emptyPosition) <= .3)
        {
            return true;
        }
        else
            return false;
    }
    bool LerpDown()
    {
        barTransform.anchoredPosition = Vector3.Lerp(barTransform.anchoredPosition, startPosition, Time.deltaTime * 4f);

        if (Vector3.Distance(barTransform.anchoredPosition, startPosition) <= .3)
        {
            return true;
        }
        else
            return false;
    }
}
