using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public Transform target;
    public int llavesParaSeguir;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LLavesText.llavesCantidad >= llavesParaSeguir){
            transform.LookAt(target);

            transform.Translate(
                transform.forward * 2f * Time.deltaTime,
                Space.World
                );
        }
        
    }

    private void OnTriggerEnter(Collider c) {

        if(c.tag == "Player"){
                SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }
}
