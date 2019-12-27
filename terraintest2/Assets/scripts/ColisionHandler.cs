using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColisionHandler : MonoBehaviour
{
    [Tooltip("en segundos")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("El objeto de explosion")][SerializeField] GameObject deathFX;



    private void OnTriggerEnter(Collider other)
    {      
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", 4f); //vuelve a emepzar
    }

    private void StartDeathSequence()
    {
       SendMessage("OnPlayerDeath");
    }

    private void ReloadScene() //referenciado por OntriggerEnter
    {
        SceneManager.LoadScene(1);
    }
}
