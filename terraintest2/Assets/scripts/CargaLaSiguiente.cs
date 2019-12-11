using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CargaLaSiguiente : MonoBehaviour
{


    //creo un objeto antes de todo con awake
    //creo un objeto permanetne a todo el juego
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 6f); // Espera dos segundos antes de lanzar la carga
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }


    
}
