using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class perder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c) {

        if(c.tag == "Player"){
                //Destroy(c.gameObject);
                //SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
                SceneManager.LoadScene(3);
        }
    }
}
