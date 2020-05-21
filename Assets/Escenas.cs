using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Escenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void EscenaPlay(){
        SceneManager.LoadScene(1);
    }

    public void EscenaAbout(){
        SceneManager.LoadScene(2);
    }

    public void Salir(){
        Application.Quit();
    }
}
