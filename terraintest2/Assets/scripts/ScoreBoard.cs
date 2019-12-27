using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private int puntuacion = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = puntuacion.ToString();
    }

   public void ScoreHit(int puntosASumar)
    {
        puntuacion = puntuacion + puntosASumar;
        scoreText.text = puntuacion.ToString();
    }
}
