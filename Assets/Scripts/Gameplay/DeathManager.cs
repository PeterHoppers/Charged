using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

    static Attempts attempts;                                                          //References the scoreManager
    static Vector3 currentPosition;
    static GameObject trailRenderer;
    static GameObject canvas;
    public static bool p1CanShoot;
    public static bool p2CanShoot;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        if(PlayerManager.numberOfPlayers == 1)
        {
            attempts = GameObject.Find("Attempts").GetComponent<Attempts>();     //References the scoreManager
        }
        p1CanShoot = true;
        p2CanShoot = true;
    }

    public static void killProjectile(GameObject player)
    {
        switch(player.tag)
        {
            case "PlayerOneProjectile":
                p1CanShoot = true;
                break;
            case "PlayerTwoProjectile":
                p2CanShoot = true;
                break;
        }
        trailRenderer = player.transform.FindChild("TrailRenderer").gameObject;
        currentPosition = trailRenderer.transform.position;
        trailRenderer.transform.SetParent(canvas.transform);
        trailRenderer.transform.position = currentPosition;
        Destroy(player.gameObject);                                                  //Destroyes the player and updates the score
        if(PlayerManager.numberOfPlayers == 1)
        attempts.Attempted();
    }
}
