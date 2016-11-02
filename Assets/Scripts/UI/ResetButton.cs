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
        if(shooting.isActive)                   //needs to make sure it cannot fire twice
            DeathManager.killProjectile();
    }
}