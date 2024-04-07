using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Timer : MonoBehaviour
{
    public float timer = 600.0f;  
    public TextMeshProUGUI timeLeft_text;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timeLeft_text.SetText("Temps restant : "+Mathf.FloorToInt(timer / 60) + " : " + Mathf.FloorToInt(timer % 60));
    }
}
