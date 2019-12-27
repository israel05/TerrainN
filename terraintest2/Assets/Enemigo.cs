using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
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
        print("Particulas colisionando con enemigo " + gameObject.name);
        Destroy(gameObject);
       
    }
}
