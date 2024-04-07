using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;

public class Script_Circle : MonoBehaviour
{
    protected Animator animator;
    public float TimerBeforeEnd = 600.0f;
    protected SpriteRenderer spriteRenderer;
    public SpriteRenderer fader_renderer;
    protected float current_alpha = 0;

    // Make a liste of scene
    public List<string> sceneList = new List<string>();

    //Recuperer le nom de la scene courante
    protected string currentSceneName;
    public bool isSceneOuverte = false;
    public bool firstTeleport = false;
    public bool firstSentenceInLoge1 = false;
    public bool firstTimeInLoge1 = true;

    public Script_Porte Porte;

       private bool isInTriggerPorteRetour = false;
    private bool isInTriggerPorteFond = false;

    private int getSceneIndex(string sceneName,int xPos)
    {
    //Loge1, Loge2, Bureau, Couloir, AScene, Scene, Regie
        //Reprendre la position du joueur et la comparer avec les positions des portes
        xPos = (int)transform.position.x;
        Debug.Log("index : " + xPos);
        Transform spriteTransform = gameObject.transform;

        switch (sceneName)
        {
            case "Loge1":
                spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                return 3;
            case "Loge2":
                spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                return 3;
            case "Bureau":
                spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                return 3;
            case "Couloir":
                if (xPos < -4)
                {
                    // Reduire la taille du sprite
                    spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                    return 2;
                }
                else if (xPos <= -0 && xPos >= -4)
                {
                    spriteTransform.localScale = new UnityEngine.Vector3(0.3f, 0.3f, 0.3f);
                    return 0;
                }
                else if(xPos >= 0 && xPos <= 4)
                {
                    spriteTransform.localScale = new UnityEngine.Vector3(0.3f, 0.3f, 0.3f);
                    return 1;
                }
                else if (xPos > 4)
                {
                    spriteTransform.localScale = new UnityEngine.Vector3(0.25f, 0.25f, 0.25f);
                    return 4;
                }
                else
                {
                    Debug.Log("Error Couloir");
                    return 0;
                }
            case "AScene":
                if (xPos <= -4)
                {
                    spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                    return 3;
                }
                else if (xPos > -4 && xPos < 4)
                {
                    spriteTransform.localScale = new UnityEngine.Vector3(0.3f, 0.3f, 0.3f);
                    return 6;
                }
                else if (xPos >= 4)
                {
                    spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                    return 5;
                }
                else
                {
                    Debug.Log("Error AScene");
                    return 0;
                }
            case "Scene":
                spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                return 4;
            case "Regie":
                spriteTransform.localScale = new UnityEngine.Vector3(0.2f, 0.2f, 0.2f);
                return 4;
            default:
                Debug.Log("Error default");
                return 0;
        }
    }
    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        // Check if another Circle object already exists
        if (FindObjectsOfType<Script_Circle>().Length > 1)
        {
            // Destroy the new Circle object
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    animator = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    sceneList.Add("Loge1");
    sceneList.Add("Loge2");
    sceneList.Add("Bureau");
    sceneList.Add("Couloir");
    sceneList.Add("AScene");
    sceneList.Add("Scene");
    sceneList.Add("Regie");
    //Loge1, Loge2, Bureau, Couloir, AScene, Scene, Regie
    }

// Update is called once per frame
int direction = 0;
void Update()
    {   
        TimerBeforeEnd -= Time.deltaTime;
        
        currentSceneName = SceneManager.GetActiveScene().name;
        // Move right and left
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(3.0f, 0.0f);
            animator.SetBool("IsWalking", true);
            spriteRenderer.flipX = false;
        }else if (Input.GetKey(KeyCode.LeftArrow)){
            direction = -1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(-3.0f, 0.0f);
            animator.SetBool("IsWalking", true);
            spriteRenderer.flipX = true;
        }else{
            direction = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetBool("IsWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        // If x > 9,30 change scene
        if (transform.position.x > 5.60f)
        {
            StartCoroutine(LoadScene_Game(sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]));
            transform.position = new Vector2(-5.50f, -1);
            Debug.Log("Scene suivante : " + sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]);
        }
        else if (transform.position.x < -5.60f)
        {
            StartCoroutine(LoadScene_Game(sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]));
            transform.position = new Vector2(5.50f, -1);
            Debug.Log("Scene suivante : " + sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]);
        }


        if (isInTriggerPorteRetour){
            //Debug.Log(Porte);
            //Si on appuie sur fleche bas
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                string lastSceneName = SceneManager.GetActiveScene().name;
                StartCoroutine(LoadScene_Game(sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]));
                if (lastSceneName == "Loge1")
                {
                    transform.position = new Vector2(-4, 0);
                }
                else if (lastSceneName == "Loge2")
                {
                    transform.position = new Vector2(4, -0);
                }
                else
                {
                    transform.position = new Vector2(0, -1);
                }
            }
        }
        if(isInTriggerPorteFond){
            Debug.Log("Porte_Fond");
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                string lastSceneName = SceneManager.GetActiveScene().name;
                StartCoroutine(LoadScene_Game(sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]));
                if (lastSceneName == "Loge1")
                {
                    transform.position = new Vector2(-4, 0);
                }
                else if (lastSceneName == "Loge2")
                {
                    transform.position = new Vector2(4, -0);
                }
                else
                {
                    transform.position = new Vector2(0, -1);
                }
                
                Debug.Log("Scene suivante : " + sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]);   
            }
        }

        
    }


    IEnumerator LoadScene_Game(string sceneName)
{
    fader_renderer.color = new Color(0, 0, 0, 1);
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
    while (!asyncLoad.isDone)
        {
            yield return null;
        }

    while (current_alpha < 0.5f)
    {
        current_alpha += Time.deltaTime/2;
        fader_renderer.color = new Color(0, 0, 0, 1-current_alpha*2);
        yield return null;
    }
    current_alpha = 0;
}

    void OnTriggerStay2D(Collider2D col){
        if (col.tag == "PorteRetour"){
            //Debug.Log(Porte);
            //Si on appuie sur fleche bas
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
             StartCoroutine(LoadScene_Game(sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]));
                transform.position = new Vector2(0, -1);
                Debug.Log("Scene suivante : " + sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]);   
            }
        }
        if(col.tag == "Porte_Fond"){
            Debug.Log("Porte_Fond");
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(LoadScene_Game(sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]));
                transform.position = new Vector2(0, -1);
                Debug.Log("Scene suivante : " + sceneList[getSceneIndex(currentSceneName, (int)transform.position.x)]);   
            }
        }
    }

 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PorteRetour")
        {
            isInTriggerPorteRetour = true;
        }
        if (col.tag == "Porte_Fond")
        {
            isInTriggerPorteFond = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "PorteRetour")
        {
            isInTriggerPorteRetour = false;
        }
        if (col.tag == "Porte_Fond")
        {
            isInTriggerPorteFond = false;
        }
    }
}
