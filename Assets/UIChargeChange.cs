using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIChargeChange : MonoBehaviour
{
    public bool isIncrease;
    Button button;
    ControlScript controls;
	// Use this for initialization
	void Start ()
    {
        button = GetComponent<Button>();
        controls = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ControlScript>();

        button.onClick.AddListener(ChangePower);
    }

    void ChangePower()
    {
        if (isIncrease)
            controls.ChargingUp();
        else
            controls.CoolingDown();
    }
}

