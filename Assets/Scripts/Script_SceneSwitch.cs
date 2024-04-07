using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_SceneSwitch : MonoBehaviour
{   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the game object of the player
        GameObject joueur = GameObject.FindGameObjectWithTag("Player");
        // Get the script Script_Circle from the player
        Script_Circle scriptCircle = joueur.GetComponent<Script_Circle>();
        GameObject sceneFermer = GameObject.FindGameObjectWithTag("SceneFermer");
        //Get sprite renderer of the scenefermer
        SpriteRenderer sceneF = sceneFermer.GetComponent<SpriteRenderer>();

        if (joueur == null){
            Debug.Log("joueur est null");
        }
        if (sceneFermer == null){
            Debug.Log("sceneFermer est null");
        }
        if (scriptCircle.isSceneOuverte)
        {   
            Debug.Log("scene ouverte");
            this.gameObject.SetActive(true);
            sceneF.enabled = false;
        }
        else
        {   
            Debug.Log("scene fermer");
            this.gameObject.SetActive(false);
            sceneF.enabled = true;
        }
    }
}
