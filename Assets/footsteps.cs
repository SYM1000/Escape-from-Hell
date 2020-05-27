using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
      cc = GetComponent<CharacterController>();
      audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){

        if(cc.isGrounded == true && cc.velocity.magnitude > 1f && audio.isPlaying == false && cc.velocity.magnitude < 4f){

            audio.volume = Random.Range(0.8f , 1);
            audio.pitch = Random.Range(0.8f, 1.1f);

            audio.Play();
        }else if(cc.isGrounded == true && cc.velocity.magnitude > 4f && audio.isPlaying == false){
            audio.volume = Random.Range(0.8f , 1);
            audio.pitch = Random.Range(1.45f, 2f);

            audio.Play();
        }
        
    }
}
