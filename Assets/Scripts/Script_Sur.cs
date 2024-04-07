using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Sur : MonoBehaviour
{
    public GameObject joueur;

    public Sprite sprite;
    public Sprite spriteSur;

    public float triggerDistance = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joueur == null)
        {
            joueur = GameObject.FindGameObjectWithTag("Player");
            if (joueur == null)
            {
                Debug.Log("il est vraiment nul");
            }
        }
        float norme = Vector2.Distance(joueur.transform.position, transform.position);
        if (norme < triggerDistance)
        {
            GetComponent<SpriteRenderer>().sprite = spriteSur;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        
    }
}
