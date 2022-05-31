using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Destructable
{
    public GameObject deathEffect;

    public override void Die()
    {
        base.Die();
        Instantiate(deathEffect, this.gameObject.transform.position, Quaternion.identity); 
        DestroyObject(this.gameObject);
            

    }

    public override void TakeDamage (float amount)
    {
        base.TakeDamage (amount);
    }
}
