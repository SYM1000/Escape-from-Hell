using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlavesSpawner : MonoBehaviour
{
    public GameObject llave;
    public Transform[] ubicaciones;

    public int LLavesGeneradas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LLavesGeneradas; i++){
            
            int lugarRandom = Random.Range(0,ubicaciones.Length-1);

            //Generar la llave
            Instantiate(
            llave, 
            ubicaciones[lugarRandom].position, 
            ubicaciones[lugarRandom].rotation);
            print("llave creada");
        }
    }
}
