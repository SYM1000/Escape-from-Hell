using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject Enemgigo;
    public Transform[] lugares;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator spawnEnemy(){
        while (true){
            int lugar = Random.Range(0, 9);
        
        Instantiate(
            Enemgigo, 
            lugares[lugar].position, 
            lugares[lugar].rotation);
        
        print("Enemigo creado en lugar: " + lugar);

        yield return new WaitForSeconds(30);
        }
    }
}
