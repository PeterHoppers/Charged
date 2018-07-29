using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementSetter : MonoBehaviour
{
    public string stateToSet;
    IonPlacement ionPlacement;
    Button button;

    private void Start()
    {
        ionPlacement = GameObject.Find("GameManager").GetComponent<IonPlacement>();

        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { SetPlacementState(stateToSet); });
    }


    void SetPlacementState(string message)
    {
        ionPlacement.SetFormState(message);
    }

}
