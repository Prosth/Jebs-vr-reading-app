using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public List<GameObject> Letters = new List<GameObject>();

    private float spawnDelay = 10f;
    private float timeBetweenSpawnsMin = 7f;
    private float timeBetweenSpawnsMax = 15f;
    private int maxLetters = 20;

    public AudioClip goodHit1;
    public AudioClip goodHit2;
    public AudioClip badHit1;

    //public List<GameObject> SpawnPositions = new List<GameObject>();
   // public List<Transform> EmptySpawnPositions = new List<Transform>();

    public GameObject letterSpawner;

    public int minCorrectLetters = 3;
    public int maxCorrectLetters = 6;

    private GameObject lvlPicker;
    private GameObject lvlManager;

    private letter_spawner letterSpawnScript;
    private level_manager mngScript;
    private LevelPicker lvlPickerScript;

    private float startTime;
    public int currentLetterInt;
    public string currentLetterStr;
    private bool startSpawning;
    private float lastSpawnTime;
    private float currentSpawnInterval;
    private float letterLifeSpan = 6f;
    private float letterLifeSpanMin = 4f;
    private float letterLifeSpanMax = 8f;

    private bool positionOfCorrectLetter = false;
    private bool positionFull = false;


    private int totalLettersInGrid = 0;

    private AudioSource audioComponent;

    // Start is called before the first frame update
    void Start()
    {
        lvlManager = GameObject.Find("Level_Manager");

        lvlPicker = GameObject.Find("Level_Manager/LevelPicker");

        currentSpawnInterval = Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);

        //GET LEVEL MANAGER SCRIPT
        mngScript = lvlManager.GetComponent("level_manager") as level_manager;

        //GET LETTER SPAWNER SCRIPT
        letterSpawnScript = letterSpawner.GetComponent("letter_spawner") as letter_spawner;

        //GET THE CURRENT CORRECT LETTER FOR THE LEVEL FROM LEVEL MANAGER                  
        currentLetterInt = mngScript.currentLetterInt;

        //INIT START TIME AND FIRST RANDOM INTERVAL
        startTime = Time.time;

        //SpawnPositions.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));

        //totalLettersInGrid = SpawnPositions.Count;

        spawnDelay = Random.Range(3f, 10f);

        audioComponent = GetComponent("AudioSource") as AudioSource;

        currentLetterStr = mngScript.letterLvl;
    }

    // Update is called once per frame
    void Update()
    {
        
        //int emptyPositions = EmptyPositions();
        //Debug.Log("empty: " + emptyPositions +" , Time counddown  " + (Time.time - startTime));
        //WAIT FOR COUNTDOWN BEFORE STARTING

        if ((Time.time - startTime) >= spawnDelay)
        {
            startSpawning = true;
        }

        //SPAWN
        if (startSpawning)
        {
            if (!positionFull)
            {
                if(Time.time - lastSpawnTime >= currentSpawnInterval)
                {
                    SpawnALetter(currentLetterInt, true);
                    letterLifeSpan = Random.Range(letterLifeSpanMin, letterLifeSpanMax);
                    currentSpawnInterval = Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);
                    positionFull = true;
                    lastSpawnTime = Time.time;
                }
            }

            if (positionFull)
            {
                if (Time.time - lastSpawnTime >= letterLifeSpan)
                {
                    DestroyAllChildren();
                    positionFull = false;
                    currentSpawnInterval = Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);
                    letterLifeSpan = Random.Range(letterLifeSpanMin, letterLifeSpanMax);
                    lastSpawnTime = Time.time;
                }

                if (transform.childCount == 0)
                {
                    positionFull = false;
                    lastSpawnTime = Time.time;
                    currentSpawnInterval = Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);
                    letterLifeSpan = Random.Range(letterLifeSpanMin, letterLifeSpanMax);
                }
            }
            
        }
    }

    public void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void SpawnALetter(int currentLetterInt, bool capital)
    {

        /*
                int correctLettersAvailable = CorrectLetterPositions();
                if (correctLettersAvailable <= minCorrectLetters)
                {
                    letterSpawnScript.CallSpawnLetter(currentLetterInt, capital, transform.position, transform.rotation.eulerAngles);
                    return;
                } 
                if (correctLettersAvailable >= maxCorrectLetters)
                {
                    letterSpawnScript.CallSpawnLetter(RandomRangeExcept(0,2,currentLetterInt), capital, transform.position, transform.rotation.eulerAngles);

                    return;
                }*/
        letter_meshes letterScript = Letters[Random.Range(0, 3)].GetComponent<letter_meshes>();

        GameObject cloneLetter = letterScript.SpawnLetter(capital, transform.position, transform.rotation.eulerAngles, new Vector3(1.2f, 1.2f, 1.2f));
        cloneLetter.transform.parent = transform;
        cloneLetter.transform.localScale = new Vector3(1, 1, 1);
    }
/*
    public int EmptyPositions()
    {
        int numberOfEmptyPositions = 0;
        bool empty = false;
        foreach(GameObject position in SpawnPositions)
        {
            if(!(position.GetComponent("SpawnPointScript") as SpawnPointScript).positionFull)
            {
                empty = true;
                numberOfEmptyPositions++;
            }
        }
        return numberOfEmptyPositions;     
    }


    public int CorrectLetterPositions()
    {
        int numberOfCorrectLetterPositions = 0;
        foreach (GameObject position in SpawnPositions)
        {
            if ((position.GetComponent("SpawnPointScript") as SpawnPointScript).positionOfCorrectLetter)
            {               
                numberOfCorrectLetterPositions++;
            }
        }
        return numberOfCorrectLetterPositions;
    }

    public int RandomRangeExcept( int min, int max, int except)
    {
        int number;
        do
        {
          number = Random.Range(min, max);

        } while (number == except);
        return number;
    }
    */
    public void PlayGoodHitSound()
    {
        audioComponent.Stop();
        audioComponent.PlayOneShot(goodHit1);
    }

    public void PlayBadHitSound()
    {
        audioComponent.Stop();
        audioComponent.PlayOneShot(badHit1);
    }
}
