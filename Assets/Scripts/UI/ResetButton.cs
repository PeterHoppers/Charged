using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour
{
    public void resetProjectile()
    {
        GameObject proj;
        proj = GameObject.Find("PlayerOneProjectile(Clone)");
        if (proj == null) {
            proj = GameObject.Find("PlayerTwoProjectile(Clone)");
        }
        
        if (proj != null) {
            DeathManager.killProjectile(proj);
        }
        
    }
}