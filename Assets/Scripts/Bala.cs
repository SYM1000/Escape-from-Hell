using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();
        Rigidbody[] rbs = GetComponents<Rigidbody>();
        //3 vectores de referencia 
        //transform.up
        //transform.right
        //transform.forward

        rb.AddForce(transform.up * 50, ForceMode.Impulse);

        Destroy(gameObject, 3); //Se puede destruir gameobject, component o asset


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision c) {


        if(c.gameObject.GetComponent<Rigidbody>()){
        Rigidbody rbc = c.gameObject.GetComponent<Rigidbody>();

        rbc.AddExplosionForce(
                    100,
                    new Vector3(0,0,0),
                    1); 

        }
    }
}
