using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class UIAngleChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isClockwise;
    bool isChangeing;
    ControlScript controls;

    // Use this for initialization
    void Start()
    {
        controls = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ControlScript>();
    }

    void Update()
    {
        if (!isChangeing)
        {
            ChangeAngle();
        }
    }

    void ChangeAngle()
    {
        if (isClockwise)
            controls.AimingUp();
        else
            controls.AimingDown();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isChangeing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isChangeing = false;
    }
}
