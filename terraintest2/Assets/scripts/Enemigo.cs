using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    [SerializeField] GameObject deathFX; //la animaciónde muerte
    [SerializeField] Transform parent;
    // Start is called before the first frame update



    void Start()
    {
        AddNonTriggerBoxColidder();       

    }

    private void AddNonTriggerBoxColidder()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>(); //añadimos los coliders en creacción
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;    
        Destroy(gameObject);
       
    }
}
