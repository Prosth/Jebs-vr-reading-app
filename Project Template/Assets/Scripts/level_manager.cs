using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class level_manager : MonoBehaviour
{
    
    public  string letterLvl;
    Scene LoadedScene;
    letter_spawner letterSpawnScript;

    public Vector3[,] grid1;
    public Vector3[,] grid2;

    public Dictionary<string, int> LettersDiction = new Dictionary<string, int>();
    public GameObject letterSpawner;

    public int currentLetterInt;


    void Awake()
    {

        //MAKE SURE THAT ONLY ONE LEVEL MANAGER EXISTS
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        //CHECK IF AT MAIN_HUB SCENE
        if (letterLvl != null)
        {
            //IF INSIDE LEVEL THEN GENERATE 3 GRIDS OF LETTER SPAWN POINTS AT VARIOUS DISTANCES
            if (!string.Equals(letterLvl, "main"))
            {
                
                LettersDiction.TryGetValue(letterLvl, out currentLetterInt);

                //Spawn two distant grids of letters

                grid1 = letterSpawnScript.CreateGrid(4, 4, 7.0f, currentLetterInt, 110f, 0.4f, 1.1f);
                grid2 =letterSpawnScript.CreateGrid(5, 3, 12f, currentLetterInt, 90f, 0.5f, 1.50f);
                //letterSpawnScript.starSpawning(grid1, currentLetterInt, 1.1f);
            }
        }
    }



    void Start()
    {
        //GET LETTER SPAWNER SCRIPT
        letterSpawnScript = letterSpawner.GetComponent("letter_spawner") as letter_spawner;
        LoadedScene = SceneManager.GetActiveScene();
    }

    //CREATE A DICTIONARY WITH INTEGER VALUES FOR ALL LETTERS
    private void PopulateDictionary()
    {
        LettersDiction.Add("A", 0);
        LettersDiction.Add("B", 1);
        LettersDiction.Add("C", 2);
        LettersDiction.Add("D", 3);
        LettersDiction.Add("E", 4);
        LettersDiction.Add("F", 5);
 /*       LettersDiction.Add("g", 6);
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
        LettersDiction.Add("z", 25); */
        LettersDiction.Add("a", 26);
        LettersDiction.Add("b", 27);
        LettersDiction.Add("c", 28);
        LettersDiction.Add("d", 29);
        LettersDiction.Add("e", 30);
        LettersDiction.Add("f", 31);
    }
   
}
