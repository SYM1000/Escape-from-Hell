using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LLavesText : MonoBehaviour
{
    // Start is called before the first frame update

    Text ConteoDeLLaves;
    public static int llavesCantidad = 0;


    void Start(){
       ConteoDeLLaves = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update(){
        ConteoDeLLaves.text = "Llaves: " + llavesCantidad;
        
    }
}
