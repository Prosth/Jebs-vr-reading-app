using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class level_manager : MonoBehaviour
{
    
    public  string letterLvl;
    Scene LoadedScene;
    letter_spawner letterSpawnScript;

    public Dictionary<string, int> LettersDiction = new Dictionary<string, int>();
    public GameObject letterSpawner;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("lvlmanager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        PopulateDictionary();

    }


    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("SCENE LOADED");
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if (letterLvl != null)
        {
            Debug.Log("level: " + letterLvl);
            if(!string.Equals(letterLvl, "main"))
            {
                int currentLetter;
                LettersDiction.TryGetValue(letterLvl, out currentLetter);
                letterSpawnScript.CreateGrid(5, 4, 1.2f, currentLetter, 150.00f);
                letterSpawnScript.CreateGrid(4, 3, 7.0f, currentLetter, 110f, 0.4f, 0.85f);
                letterSpawnScript.CreateGrid(5, 2, 12f, currentLetter, 90f, 0.5f, 1.00f);
            }
        }
    }



    void Start()
    {
        letterSpawnScript = letterSpawner.GetComponent("letter_spawner") as letter_spawner;
        LoadedScene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + LoadedScene.name + "'.");
        
    }


    private void PopulateDictionary()
    {
        LettersDiction.Add("a", 0);
        LettersDiction.Add("b", 1);
        LettersDiction.Add("c", 2);
        LettersDiction.Add("d", 3);
        LettersDiction.Add("e", 4);
        LettersDiction.Add("f", 5);
        LettersDiction.Add("g", 6);
        LettersDiction.Add("h", 7);
        LettersDiction.Add("i", 8);
        LettersDiction.Add("j", 9);
        LettersDiction.Add("k", 10);
        LettersDiction.Add("l", 11);
        LettersDiction.Add("m", 12);
        LettersDiction.Add("n", 13);
        LettersDiction.Add("o", 14);
        LettersDiction.Add("p", 15);
        LettersDiction.Add("q", 16);
        LettersDiction.Add("r", 17);
        LettersDiction.Add("s", 18);
        LettersDiction.Add("t", 19);
        LettersDiction.Add("u", 20);
        LettersDiction.Add("v", 21);
        LettersDiction.Add("w", 22);
        LettersDiction.Add("x", 23);
        LettersDiction.Add("y", 24);
        LettersDiction.Add("z", 25);
        LettersDiction.Add("A", 26);
        LettersDiction.Add("B", 27);
        LettersDiction.Add("C", 28);
        LettersDiction.Add("D", 29);
        LettersDiction.Add("E", 30);
        LettersDiction.Add("F", 31);
    }
   
}
