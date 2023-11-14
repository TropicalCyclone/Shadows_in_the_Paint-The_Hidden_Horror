using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamicSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public static DynamicSceneManager instance { get; private set; }  
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        Load("Tutorial Level");
        Load("Easy Level");
        //Load("Medium Level");
        //Load("Final Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Load(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
    }

    public void Unload(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
