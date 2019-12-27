using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); //para que no exista en la 
        //lsita de runnings para siempre
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
