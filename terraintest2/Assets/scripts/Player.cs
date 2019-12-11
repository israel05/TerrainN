﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("En metros por segundo")][SerializeField] float xSpeed= 4f;
    [Tooltip("desde el centro hasta salir de cámara")] [SerializeField] float posibleStrafe = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * xSpeed *Time.deltaTime;
        float rawXNewXPos = transform.localPosition.x + xOffsetThisFrame;
        float posicionRestringida = Mathf.Clamp(rawXNewXPos, -posibleStrafe, posibleStrafe);
        transform.localPosition = new Vector3(
            posicionRestringida, 
            transform.localPosition.y, 
            transform.localPosition.z);
        
    }
}
