using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosAleatorios : MonoBehaviour
{
    public AudioClip[] sonidos;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(ReproducirSonidos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ReproducirSonidos(){

        while(true){
            int numero = Random.Range(0, sonidos.Length-1);
            audio.PlayOneShot(sonidos[numero], 0.9F);

            yield return new WaitForSeconds(21);
        }
        
    }
}
