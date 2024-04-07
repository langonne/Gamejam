using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Menu scene loaded");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadSpawnScene()
    {
        Debug.Log("Loading Spawn scene");
        StartCoroutine(LoadScene_Game("loge1"));
    }

    IEnumerator LoadScene_Game(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
