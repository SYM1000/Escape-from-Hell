using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    private GameObject target;
    public int llavesParaSeguir;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    { 
        // agent = GetComponent<NavMeshAgent>();
        // agent.SetDestination(target.position);

        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(LLavesText.llavesCantidad >= llavesParaSeguir){
            transform.LookAt(target.transform);

            transform.Translate(
                transform.forward * 2f * Time.deltaTime,
                Space.World
                );
        }
        
    }

    
}
