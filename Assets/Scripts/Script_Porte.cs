using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Porte : MonoBehaviour
{
    public GameObject Porte_Ferme;
    public GameObject Porte_Ouverte;
    // Start is called before the first frame update
    void Start()
    {
        Porte_Ouverte.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PorteFerme(){
        Porte_Ouverte.SetActive(true);
        Porte_Ferme.SetActive(false);
    }

    public void PorteOuverte(){
        Porte_Ferme.SetActive(true);
        Porte_Ouverte.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.tag == "Player"){
            //Debug.Log(Porte);
            PorteFerme();
        }
        
    }
    
    void OnTriggerExit2D(Collider2D col){
        if (col.tag == "Player"){
            //Debug.Log("Debug");
            PorteOuverte();
        }
    }

    void OnTriggerStay2D(Collider2D col){
        
        if(col.tag == "Porte_Fond"){

        }
    }
}
