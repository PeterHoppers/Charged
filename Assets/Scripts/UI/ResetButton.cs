using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour
{
    Shooting shooting;
    void Start()
    {
        shooting = GameObject.Find("GunBarrel").GetComponent<Shooting>();
    }
    public void resetProjectile()
    {
        if(shooting.isActive)
        DeathManager.killProjectile();
    }
}