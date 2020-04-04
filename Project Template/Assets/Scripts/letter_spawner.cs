using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_spawner : MonoBehaviour
{
    public GameObject spawnPointer;

    public List<GameObject> Letters = new List<GameObject>();

    public List<Transform> SpawnPositions = new List<Transform>();
    public List<Transform> EmptySpawnPositions = new List<Transform>();

    // number of rows and Columns of letters to spawn 
    public int spawnCols = 4;
    public int spawnRows = 4;

    //spawn parameters
    public float spawnArchAngle = 140f;

    public float spawnHeightOffset = 0.5f;
    public float spawnGapHeight = 0.5f;

    Vector3 spawn_vec0;
    //Vector3[,] spawnPoints;
    Vector3 defaultScale = new Vector3(1, 1, 1);


    Vector3[,] mGrid;

    public float spawnDelay = 3f;
    public float timeBetweenSpawnsMin = 1f;
    public float timeBetweenSpawnsMax = 5f;
    public int maxLetters = 16;

    private List<mLetter> spawnedLetters = new List<mLetter>();
    private Queue<mLetter> inactiveLetters = new Queue<mLetter>();



    public Vector3[,] CreateGrid(int spawnCols, int spawnRows, float spawnDistance, int letter, float spawnArchAngle = 140, float spawnHeightOffset = 0.5f ,float spawnGapHeight = 0.5f)
    {
        //calculate angle based on how many rows of letters will appear
        float spawnAngle = spawnArchAngle / spawnCols;
        Vector3[,] spawnPoints = new Vector3[spawnCols, spawnRows];

        //initialize the first vector
        Vector3 spawn_vec0 = new Vector3(spawnDistance, 0, 0);
        float angleOffset = (180 - spawnArchAngle) / 2;
        float angleOffsetInit = angleOffset + spawnAngle / 2;
        spawn_vec0 = Quaternion.AngleAxis(-angleOffsetInit, Vector3.up) * spawn_vec0;

        //Create vectors alog which the letters will spawn
        for (int i = 0; i < spawnCols; i++)
        {
            for (int j = 0; j < spawnRows; j++)
            {
                spawnPoints[i, j] = Quaternion.AngleAxis(-spawnAngle * i, Vector3.up) * spawn_vec0;
                spawnPoints[i, j].y = +spawnHeightOffset + j * spawnGapHeight;
                //CallSpawnLetter(letter, true, spawnPoints[i, j], Vector3.zero, spawnDistance);
                Instantiate(spawnPointer, spawnPoints[i, j], Quaternion.identity);
                spawnPointer.name = "" + i + "," + j;
                spawnPointer.transform.localScale = defaultScale * (1 + (spawnDistance / 5));
                SpawnPositions.Add(spawnPointer.transform);
                EmptySpawnPositions.Add(spawnPointer.transform);
            }
        }
        return spawnPoints;
    }


    public void CallSpawnLetter(int letter, bool upperCase, Vector3 spawnPosition, Vector3 spawnRotation, float spawnDistance = 5.00f)
    {
        Vector3 spawnScale = defaultScale * (1 + (spawnDistance/5));
        letter_meshes letterScript = Letters[letter].GetComponent<letter_meshes>();
        letterScript.SpawnLetter(upperCase, spawnPosition, spawnRotation, spawnScale);
    }



/*
    private IEnumerator SpawnLetter(Vector3[,] grid)
    {
        //wait before spawning
        yield return new WaitForSeconds(spawnDelay);

        //Spawning loop
        while (this.isActiveAndEnabled)
        {
            if (inactiveLetters.Count > 0)
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


                //GET RANDOM POSITION ON GRID
                int rndCol = Random.Range(0, mGrid.GetLength(0));
                int rndRow = Random.Range(0, mGrid.GetLength(1));

                position = grid[rndCol, rndRow];
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

}
