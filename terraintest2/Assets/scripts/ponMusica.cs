using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponMusica : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<ponMusica>().Length;
       if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }


    }
}
