using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

    static Attempts attempts;                                                          //References the scoreManager
    static Vector3 currentPosition;
    static GameObject trailRenderer;
    static GameObject canvas;
    private static IonPlacement ionPlacement;
    private static bool origPosIon;
    private static bool origNegIon;
    public static bool p1CanShoot;
    public static bool p2CanShoot;
    public static bool isFinished = false;

    void Start()
    {
        isFinished = false;
        canvas = GameObject.Find("Canvas");
        if(PlayerManager.numberOfPlayers == 1)
        {
            attempts = GameObject.Find("Attempts/Time").GetComponent<Attempts>();     //References the scoreManager
            ionPlacement = gameObject.GetComponentInChildren<IonPlacement>();
            origPosIon = ionPlacement.cannotPlacePositive;                              // What is it set to originally?
            origNegIon = ionPlacement.cannotPlaceNegative;
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
                ionPlacement.cannotPlacePositive = origPosIon;                          // After the the shot is done,
                ionPlacement.cannotPlaceNegative = origNegIon;                          // Return placement to original.
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
        {
            attempts.Attempted();
        }
    }
}
