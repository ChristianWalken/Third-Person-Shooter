using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]float speed;
    [SerializeField]float timeToLive;
    [SerializeField]float damage;
    public GameObject impactEffect;


    void Start(){
        Destroy(gameObject, timeToLive);
    }
    void Update() {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other){
       Instantiate(impactEffect, this.gameObject.transform.position, Quaternion.identity); 

       var destructable = other.transform.GetComponent<Destructable>();
       if(destructable == null)
            return;

        destructable.TakeDamage(damage);
        DestroyObject(this.gameObject); 
    }
}
