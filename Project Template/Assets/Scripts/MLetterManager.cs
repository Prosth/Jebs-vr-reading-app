using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLetterManager : MonoBehaviour
{
    public GameObject letterPrefab;
    public GameObject letterSpawnerObj;
    public GameObject oldManager;

    level_manager levelManagerScript;
    letter_spawner letterSpawnerScript;

    Vector3[,] mGrid;

    public float spawnDelay = 3f;
    public float timeBetweenSpawnsMin = 1f;
    public float timeBetweenSpawnsMax = 5f;
    public int maxLetters = 16;

    private List<mLetter> spawnedLetters = new List<mLetter>();
    private Queue<mLetter> inactiveLetters = new Queue<mLetter>();

    public Queue<mLetter> InactiveLetters
    {
        get { return inactiveLetters; } 
    }
    /*
    void OnEnable()
    {
        InitLetters();
        letterSpawnerScript = letterSpawnerObj.GetComponent("letter_spawner") as letter_spawner;
        levelManagerScript = oldManager.GetComponent("level_manager") as level_manager;

        StartCoroutine(SpawnLetter());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnLetter());
        ResetAllLetters();
    }

    public void InitLetters()
    {
        //CREATE PARENT GAME OBJ FOR CLEAN LOOK
        GameObject letterParent = new GameObject();
        letterParent.name = "Letters";

        for (int i = 0; i < maxLetters; i++)
        {
            mLetter letterInstance = (Instantiate(letterPrefab) as GameObject).GetComponent<mLetter>();


           
            //Register letter to manager
            letterInstance.mLettermanager = this;

            //Set parent
            letterInstance.transform.parent = letterParent.transform;

            //INIT LETTER
            letterInstance.InitLetter();

            //Add to letter list
            spawnedLetters.Add(letterInstance);     
        }

        ResetAllLetters();
    }

    private IEnumerator SpawnLetter()
    {
        //wait before spawning
        yield return new WaitForSeconds(spawnDelay);

        //Spawning loop
        while (this.isActiveAndEnabled)
        {
            if(inactiveLetters.Count > 0)
            {
                //Get inactive letters from queu
                mLetter letter = inactiveLetters.Dequeue();

                Vector3 position;
                //Choose RANDOM GRID TO GET POSITIONS

               // do
               // {
                    int[] gridNumber = new int[2];
                    gridNumber[0] = 1;
                    gridNumber[1] = 2;
                    int gridChoice = gridNumber[Random.Range(0, gridNumber.Length)];


                    if ((int)gridChoice == 0)
                    {
                        mGrid = levelManagerScript.grid1;
                    }
                    else
                    {
                        mGrid = levelManagerScript.grid2;
                    }

                    //GET RANDOM POSITION ON GRID
                    int rndCol = Random.Range(0, mGrid.GetLength(0));
                    int rndRow = Random.Range(0, mGrid.GetLength(1));

                    position = mGrid[rndCol, rndRow];
                //}
                //while ();

                letter.transform.position = position;

                //Activate letter
                letter.Activate();
            }

            float waitTime = Random.Range(timeBetweenSpawnsMin, timeBetweenSpawnsMax);

            yield return new WaitForSeconds(waitTime);        
        }
    }
    */
    private void ResetAllLetters()
    {
        //clear letter queue
        inactiveLetters.Clear();

        //Reser each Letter
        foreach(mLetter letter in spawnedLetters)
        {
            letter.Reset();
        }
    }

}
