using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IralHospital : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        print("Cambio de escena al hospital");
        //SceneManager.LoadScene("Hospital");
        SceneManager.LoadScene(6);
        //LLaves se pueden reiniciar a 0 aqui
    }
}
