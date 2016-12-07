using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

    public static bool canShoot;
    public static bool isFinished = false;

    private static Attempts attempts;
    private static Vector3 currentPosition;
    private static GameObject trailRenderer;
    private static GameObject canvas;
    
    void Start()
    {
        isFinished = false;                                                      // Is the game finished?

        canvas = GameObject.Find("Canvas");
        if (canvas == null)
            Debug.LogError("No canvas found.");

        attempts = GameObject.Find("Attempts/Time").GetComponent<Attempts>();     //References the scoreManager
        if (attempts == null) {
            Debug.LogError("No Attempts script found on the Attempts/Time");
        }

        canShoot = true;
    }

    public static void killProjectile(GameObject player)
    {
        if(player.tag == "Projectile")
        {
            canShoot = true;
        }

        // ================ Use Trail Renderer to show path of all the projectiles =================
        trailRenderer = player.transform.FindChild("TrailRenderer").gameObject;
        currentPosition = trailRenderer.transform.position;
        trailRenderer.transform.SetParent(canvas.transform);
        trailRenderer.transform.position = currentPosition;

        // Destroys the player and updates the score.
        Destroy(player.gameObject);                                                  
        attempts.Attempted();
    }
}
