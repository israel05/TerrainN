using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("parametros generales")]

    [Tooltip("En metros por segundo")] [SerializeField] float xSpeed = 40f;
    [Tooltip("desde el centro hasta salir de cámara")] [SerializeField] float posibleStrafe = 30f;
    [Tooltip("En metros por segundo")] [SerializeField] float ySpeed = 40f;
    [Tooltip("desde el centro hasta salir de cámara")] [SerializeField] float posibleVertical = 10f;
    [Header("parametros limitación")]
    [SerializeField] float positionPitchFactor = 0.3f;
    [SerializeField] float controlPitchFactor = -8f;
    [SerializeField] float positionYawFactor = 4f;
    [SerializeField] float controlYawFactor = -6f;
    [SerializeField] float controlRollFactor = -6f;

    [SerializeField] GameObject[] armas;

    private float xThrow;
    private float yThrow;
    bool isControlEnabled= true;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isControlEnabled)
        {
            MoverEnXeY();
            MoverEnRotacion();
            Disparar();
        }
       

    }

    void OnPlayerDeath() // called by string reference. no lo cambies de nombre porque 
                         //colission handler sendmesage fallara
    {
        print("Estoy en playercontroller y he colisionado");
        isControlEnabled = false;

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


    void OnCollisionEnter(Collision collision)
    {

        print("PLayer colided with smth");
        print(collision.gameObject.name);
    }

    void Disparar() { 
        if (CrossPlatformInputManager.GetButton("Fuego"))
        {
            ActivarArmas();
        } else
        {
            DesactivarArmas();
        }
   
    
    }

    private void DesactivarArmas()
    {
       foreach(GameObject arma in armas)
        {
            arma.SetActive(false);
        }
    }

    private void ActivarArmas()
    {
        foreach(GameObject arma in armas)
        {
            arma.SetActive(true);
        }
    }
}
