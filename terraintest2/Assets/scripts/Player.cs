﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("En metros por segundo")][SerializeField] float xSpeed= 40f;
    [Tooltip("desde el centro hasta salir de cámara")] [SerializeField] float posibleStrafe = 30f;
    [Tooltip("En metros por segundo")] [SerializeField] float ySpeed = 40f;
    [Tooltip("desde el centro hasta salir de cámara")] [SerializeField] float posibleVertical = 10f;
    [SerializeField] float positionPitchFactor = 0.3f;
    [SerializeField] float controlPitchFactor = -8f;
    [SerializeField] float positionYawFactor = 4f;
    [SerializeField] float controlYawFactor = -6f;
    [SerializeField]float controlRollFactor = -6f;
    private float xThrow;
    private float yThrow;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnXeY();
        MoverEnRotacion();

    }

    private void MoverEnRotacion()
    {
        float pitch= transform.localPosition.y * 
            positionPitchFactor +yThrow * 
            controlPitchFactor ;

        float yaw = transform.localRotation.x *
            positionYawFactor + xThrow *
            controlYawFactor;
        float roll = xThrow * controlRollFactor; 

        //ajustar la rotación mediate quaternion euleriano
       transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        
        
    }

    private void MoverEnXeY()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");


        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float yOffsetThisFrame = yThrow * ySpeed * Time.deltaTime;


        float rawXNewXPos = transform.localPosition.x + xOffsetThisFrame;
        float rawYNewYPos = transform.localPosition.y + yOffsetThisFrame;


        float posicionRestringidaX = Mathf.Clamp(rawXNewXPos, -posibleStrafe, posibleStrafe);
        float posicionRestringidaY = Mathf.Clamp(rawYNewYPos, -posibleVertical, posibleVertical);


        transform.localPosition = new Vector3(
            posicionRestringidaX,
            posicionRestringidaY,
            transform.localPosition.z);
    }
}
