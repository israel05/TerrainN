using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponMusica : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
