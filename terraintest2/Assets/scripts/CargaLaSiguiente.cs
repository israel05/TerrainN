using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CargaLaSiguiente : MonoBehaviour
{


    
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
