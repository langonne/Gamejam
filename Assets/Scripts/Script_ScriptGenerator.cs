using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Script_ScriptGenerator : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float timeBetweenLetters = 0.1f;
    public int maxLetters = 50;
    protected float tbl;
    void Start()
    {
        //Set the text on the position of the gameobject who instanced this script
        text.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (tbl > 0)
        {
            tbl -= Time.deltaTime;
        }
        else
        {
            if (text.text.Length < maxLetters)
            {
                text.text += Random.Range(0, 2);
                tbl = timeBetweenLetters;
            }
        }
    }
}
