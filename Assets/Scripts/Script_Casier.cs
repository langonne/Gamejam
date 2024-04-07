using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Casier : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject choix1;
    public GameObject choix2;
    public GameObject choix3;
    public GameObject choix4;
    public GameObject choix5;

    public bool isInChoice = false;







    public int currentChoice;
    //Declaration de la liste des choix
    public List<GameObject> choix;
    void Start()
    {
        choix = new List<GameObject>();
        currentChoice = 0;

        
        choix.Add(choix1);
        choix.Add(choix2);
        choix.Add(choix3);
        choix.Add(choix4);
        choix.Add(choix5);
        foreach (GameObject choix in choix)
        {
            choix.SetActive(false);
        }
    }

// Update is called once per frame
void Update()
{
   
    Script_interaction interaction = GetComponent<Script_interaction>();
    isInChoice = interaction.isInFinalChoice;

    if (isInChoice){
         choix[currentChoice].SetActive(true);
        //Si il appuie sur fleche droite
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Désafficher le choix actuel
            choix[currentChoice].SetActive(false);
            currentChoice++;
            if (currentChoice >= choix.Count)
            {
                currentChoice = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Désafficher le choix actuel
            choix[currentChoice].SetActive(false);
            currentChoice--;
            if (currentChoice <= 0)
            {
                currentChoice = choix.Count - 1;
            }
        }
        choix[currentChoice].SetActive(true);
    }
    else{
        foreach (GameObject choix in choix)
        {
            choix.SetActive(false);
        }
    }

}
    //Si il appuie sur fleche gauche
}
