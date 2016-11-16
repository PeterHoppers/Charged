using UnityEngine;
using System.Collections;

public class FindPlayer : MonoBehaviour {

    GameObject player;
    GameObject gun;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerOne");
        gun = player.transform.FindChild("GunBarrel").gameObject;

        if (player == null)
            Debug.LogError("No player found");

        if(gun == null)
        {
            Debug.LogError("No gun barrel found");
        }
	}

    public void ToggleControls()
    {
        player.GetComponent<ControlScript>().enabled = !player.GetComponent<ControlScript>().enabled;
        gun.GetComponent<Shooting>().enabled = !gun.GetComponent<Shooting>().enabled;
    }
}
