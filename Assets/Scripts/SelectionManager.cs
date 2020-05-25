﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour{
    public Camera cam;
    [SerializeField] private string seleccionableTag = "Seleccionable"; //Tag para poder diferenciar entre objetos que se pueden seleccinar y objetos que no
    [SerializeField] private string llaveTag = "llave";
    [SerializeField] private string EnemigoTag = "Enemigo";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    private Material materialAnterior;
    public Transform referencia; //Objeto que se está viendo con la mira
    public GameObject padre;

    private Transform _selection; //referencia al objeto que esta siendo seleccionado
    private Transform Agarrado; //referencia al objeto que se va a tener en la mano
    //private Bolean agarrandoUnObjeto = false;

    private void Start() {
        _selection = null;
        Agarrado = null;
        
    }
    void Update(){

        if (_selection != null){

            var selectionRender = _selection.GetComponent<Renderer>();
            selectionRender.material = materialAnterior;
            _selection = null;
            SimpleShoot.disparar = true;
            print("Listo para disparar");
        }


        var ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){ //Si se golpeó a un objeto. Si golpeó un objeto regresa true

            var selection = hit.transform; //El objeto que estamos viendo en el cetro de la pantalla

            if(selection.CompareTag(seleccionableTag) || selection.CompareTag(llaveTag)  ){ //Checar si es un objeto que se puede selccionar
                var selectionRenderer = selection.GetComponent<Renderer>();
                materialAnterior = selectionRenderer.material;
                SimpleShoot.disparar = false;
                print("No disparar");

                if (selectionRenderer != null){ //Aqui se cambia el material para resaltar el objeto visto

                    //var outline = selection.GetComponent<Outline>();
                    //if(outline != null) outline.OutlineWidth = 10;

                    selectionRenderer.material = highlightMaterial;
                    selectionRenderer.material.color = Color.Lerp( materialAnterior.color, selectionRenderer.material.color, Mathf.Abs( Mathf.Sin( Time.time * 3) ) );
                    
                }
                    
                 _selection = selection;
                    
                

            }else if(selection.CompareTag(EnemigoTag)){ //Si se está apuntando a un enemigo
                    
                    if ( SimpleShoot.disparar == true && Input.GetButtonDown("Fire1")){
                        if(Agarrado != null){

                            Destroy(selection.gameObject, 0.3f);

                            }
                    }
            }

            
        }

        if(Input.GetMouseButtonDown(0)){

            if(_selection != null){
                if(_selection.CompareTag(llaveTag)){
                LLavesText.llavesCantidad++;
                if(Agarrado != null){
                    SimpleShoot.disparar = true;
                }
                //Audio.llaveSonido();
                Destroy(_selection.gameObject); //Destruir la llave
                
                
                }else if (_selection.CompareTag(seleccionableTag) && Agarrado == null){
                //_selection.transform.position = Vector3.Lerp(_selection.transform.position, referencia.position, Time.deltaTime * 3);
                Agarrado = _selection;
                Agarrado.GetComponent<Rigidbody>().useGravity = false;
                Agarrado.GetComponent<Rigidbody>().isKinematic = true;
                Agarrado.transform.position = new Vector3(referencia.position.x, referencia.position.y, referencia.position.z);
                
                Vector3 eulerRotation = new Vector3(referencia.transform.eulerAngles.x, referencia.transform.eulerAngles.y, referencia.transform.eulerAngles.z);
                Agarrado.transform.rotation = Quaternion.Euler(eulerRotation);

                Agarrado.transform.parent = padre.transform;

                if(_selection.gameObject.name == "Pistola"){
                    SimpleShoot.disparar  = true;
                }
                
                Debug.Log("click al objeto");

                }else{
                    Debug.Log("Hacer nada por que se tiene un objeto en la mano");
                }


            }else{
                //Ocurre cuando se hace click y no se ha seleccionado un objeto o 
                Debug.Log("No es un objeto seleccionable");
            }
        
            


            
        }

        if(Input.GetMouseButtonDown(1)){ //Soltar el objeto
           if(Agarrado != null){
                Agarrado.transform.parent = null;
                Agarrado.GetComponent<Rigidbody>().useGravity = true;
                Agarrado.GetComponent<Rigidbody>().isKinematic = false;
                Agarrado = null;
                
                SimpleShoot.disparar  = false;

            Debug.Log("Dejar el objeto");
           }else{
               Debug.Log("No hay objeto agarrado en la mano");
               }
 
        }

        if (Input.GetKeyDown("l")){
            if(Agarrado != null){
                print("Solo para efectos de debuging con la lampara"); //Se usa solo para debug de la lampara
                GameObject lampara = Agarrado.transform.GetChild (0).gameObject; 
                Light luz = lampara.GetComponent<Light>();

                if(!luz.enabled){
                    luz.enabled = true;
                }else{
                    luz.enabled = false;
                }
            }else{
                Debug.Log("No se tiene seleccionada la lampara");
            }
        }

    }


}
