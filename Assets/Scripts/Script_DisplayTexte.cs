using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_DisplayTexte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnabledTexte()
    {
       //Desactiver le gameobject
       this.gameObject.SetActive(true);
    }

    public void DisabledTexte()
    {
        //Activer le gameobject
        this.gameObject.SetActive(false);
    }
}
