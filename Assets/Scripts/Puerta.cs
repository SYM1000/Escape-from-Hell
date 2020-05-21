using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta : MonoBehaviour{

    public int CantidadDeLLaves; //Cantidad de llaves necesaria para abrir la puerta

    public GameObject texto; 
    private bool playerInZone;                  //Check if the player is in the zone
    private bool doorOpened;                    //Check if door is currently opened or not

    private Animation doorAnim;
    private BoxCollider doorCollider;           //To enable the player to go through the door if door is opened else block him

    

    enum DoorState
    {
        Closed,
        Opened,
        Jammed
    }

    DoorState doorState = new DoorState();      //To check the current state of the door

    /// <summary>
    /// Initial State of every variables
    /// </summary>

    private void Start(){

        doorOpened = false;                     //Is the door currently opened
        playerInZone = false;                   //Player not in zone
        doorState = DoorState.Closed;           //Starting state is door closed

        texto.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider c){

        Debug.Log("alguien entró");

        if(c.tag == "Player"){
            //texto.GetComponent<Text>().text = "Necesitas " + CantidadDeLLaves + " llaves para entrar"; 
            texto.SetActive(true);
            playerInZone = true;
        }
        
    }

    private void OnTriggerExit(Collider c){
        if(c.tag == "Player"){
            playerInZone = false;
            texto.SetActive(false);
        }
        
    }

    private void Update(){
        //To Check if the player is in the zone
        if (playerInZone){

            if (doorState == DoorState.Opened){

                Debug.Log("Preciona K para cerrar");
                texto.GetComponent<Text>().text = "Preciona K para cerrar";
                doorCollider.enabled = false;

            }else if (doorState == DoorState.Closed && (LLavesText.llavesCantidad >= CantidadDeLLaves) ){

                Debug.Log("Preciona K para abrir");
                texto.GetComponent<Text>().text = "Preciona K para abrir";
                doorCollider.enabled = true;

            }else{

                Debug.Log("Necesitas llaves");
                texto.GetComponent<Text>().text = "Necesitas " + (CantidadDeLLaves - LLavesText.llavesCantidad) + " llaves para abrir la puerta";
                doorCollider.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) && playerInZone){

            doorOpened = !doorOpened;           //Cambiar el estado de la puerta

            if (doorState == DoorState.Closed && !doorAnim.isPlaying){

                if (LLavesText.llavesCantidad >= CantidadDeLLaves){
                    doorAnim.Play("Door_Open");
                    doorState = DoorState.Opened;

                }else{
                    doorAnim.Play("Door_Jam");
                    doorState = DoorState.Jammed;
                }

            }

            if (doorState == DoorState.Closed && (LLavesText.llavesCantidad >= CantidadDeLLaves) && !doorAnim.isPlaying){
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
            }

            if (doorState == DoorState.Opened && !doorAnim.isPlaying){
                doorAnim.Play("Door_Close");
                doorState = DoorState.Closed;
            }

            if (doorState == DoorState.Jammed && !(LLavesText.llavesCantidad >= CantidadDeLLaves)){
                doorAnim.Play("Door_Jam");
                doorState = DoorState.Jammed;

            }else if (doorState == DoorState.Jammed && (LLavesText.llavesCantidad >= CantidadDeLLaves) && !doorAnim.isPlaying){
                doorAnim.Play("Door_Open");
                doorState = DoorState.Opened;
            }
        }
    }
}
