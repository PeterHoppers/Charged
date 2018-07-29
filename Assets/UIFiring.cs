using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFiring : MonoBehaviour
{
    Button button;
    Shooting shooting;

    // Use this for initialization
    void Start ()
    {
        button = GetComponent<Button>();
        shooting = GameObject.FindGameObjectWithTag("PlayerOne").GetComponentInChildren<Shooting>();

        button.onClick.AddListener(Fire);
    }

    void Fire()
    {
        if (shooting != null)
            shooting.Shoot();
    }
}
