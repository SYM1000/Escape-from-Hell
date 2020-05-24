using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    private void Update() {
        
    }

    // Update is called once per frame

    public void llaveSonido(){
        player.clip = clips[1];
        player.Play();
    }
}
