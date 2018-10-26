using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class UIChargeChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isIncrease;
    Button button;
    ControlScript controls;
    bool isChangeing;
	// Use this for initialization
	void Start ()
    {
        controls = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ControlScript>();
    }

    void Update()
    {
        if (isChangeing)
        {
            ChangePower();
        }
    }

    void ChangePower()
    {
        if (isIncrease)
            controls.ChargingUp();
        else
            controls.CoolingDown();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Pointer down");
        isChangeing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Pointer up");
        isChangeing = false;
    }
}

