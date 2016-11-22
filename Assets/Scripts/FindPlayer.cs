using UnityEngine;
using System.Collections;

public class FindPlayer : MonoBehaviour {

    GameObject player;
    GameObject gun;
    GameObject ionButton;
    
	void Start ()
    {
        player = GameObject.Find("GameManager").GetComponent<PlayerManager>().p1Clone;
        gun = player.transform.FindChild("GunBarrel").gameObject;
        ionButton = GameObject.Find("IonButton");

        if (!player)
            Debug.LogError("No player found");

        if (gun == null)
        {
            Debug.LogError("No gun barrel found");
        }

        if (ionButton == null)
        {
            Debug.LogError("No ion button found");
        }
        else
        {
            ionButton.SetActive(false);
        }
	}

    public void ToggleControls()
    {
        player.GetComponent<ControlScript>().enabled = !player.GetComponent<ControlScript>().enabled;
        gun.GetComponent<Shooting>().enabled = !gun.GetComponent<Shooting>().enabled;
        ionButton.SetActive(!ionButton.activeInHierarchy);
    }
}
