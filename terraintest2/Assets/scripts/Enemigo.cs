using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemigo : MonoBehaviour
{
    [SerializeField] int puntosPorEnemigo = 14;

    [SerializeField] GameObject deathFX; //la animaciónde muerte
    [SerializeField] Transform parent;
    // Start is called before the first frame update

    ScoreBoard scoreBoard; //para poder usar la llamada public


    void Start()
    {
        AddNonTriggerBoxColidder();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        //busca los objetos de tipo scoreBoard y asocialo a mi instancia
        // tú, enemigo, vas a llamar a ese scoreBoard, el único que tengo
        // y más tarde le llamaras con los puntos que valgas
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
        scoreBoard.ScoreHit(puntosPorEnemigo);
       
    }
}
