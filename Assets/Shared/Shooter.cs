using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter :MonoBehaviour
{
    [SerializeField]float rateOfFire;
    [SerializeField]Projectile projectile;
    [HideInInspector]
    public Transform muzzle;
    public float strayFactor;

    float nextFireAllowed;
    public bool canFire;

    void Awake() {
        muzzle = transform.Find("Muzzle");
    }

    public virtual void Fire(){
        canFire = false;

        if(Time.time < nextFireAllowed)
            return;

           nextFireAllowed = Time.time + rateOfFire;
           
        var randomNumberX = Random.Range(-strayFactor, strayFactor);
        var randomNumberY = Random.Range(-strayFactor, strayFactor);
        var randomNumberZ = Random.Range(-strayFactor, strayFactor);
        //instantiate projectile
        var bullet = Instantiate(projectile, muzzle.position, muzzle.rotation);
        bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);
        canFire = true;
    }
}
