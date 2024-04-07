using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Collections.LowLevel.Unsafe;

public class Script_text : MonoBehaviour
{
    public float timeBetweenLetters = 0.1f;
    public GameObject image;
    protected string sentence;
    protected string[] words;
    private int wordIndex = 0;
    public int maxLetters = 500;
    protected float tbl;
    protected bool isSetenceInitialized = false;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        //Disable gameobject
    }

    // Update is called once per frame
    void Update()
    {
        if (isSetenceInitialized)
        {   
            if (tbl > 0)
            {
                tbl -= Time.deltaTime;
            }
            else
            {
                if (wordIndex < words.Length)
                {
                    text.text += words[wordIndex] + " ";
                    tbl = timeBetweenLetters;
                    wordIndex++;
                }

            }
        }
    }
    public void InitializedSencece(string sentence)
    {
        this.sentence = sentence;
        words = sentence.Split(' ');
        isSetenceInitialized = true;
        image.SetActive(true);
    }
    public void EndDialogue()
    {
        image.SetActive(false);
        text.text = "";
        wordIndex = 0;
        isSetenceInitialized = false;
        
    }
}