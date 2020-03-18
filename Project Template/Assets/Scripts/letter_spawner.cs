using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_spawner : MonoBehaviour
{
    public GameObject spawnPointer;

    public List<GameObject> Letters = new List<GameObject>();

    // number of rows and Columns of letters to spawn 
    public int spawnCols = 4;
    public int spawnRows = 4;

    //spawn parameters
    public float spawnArchAngle = 140f;
    public float spawnDistance = 1.00f;
    public float spawnHeightOffset = 0.5f;
    public float spawnGapHeight = 0.5f;

    Vector3 spawn_vec0;
    Vector3[,] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        //calculate angle based on how many rows of letters will appear
        float spawnAngle = spawnArchAngle / spawnCols;
        spawnPoints = new Vector3[spawnCols, spawnRows];

        //initialize the first vector
        Vector3 spawn_vec0 = new Vector3(spawnDistance, 0, 0);
        float angleOffset = (180 - spawnArchAngle) / 2;
        float angleOffsetInit = angleOffset + spawnAngle / 2;
        spawn_vec0 = Quaternion.AngleAxis(-angleOffsetInit, Vector3.up) * spawn_vec0;

        //Create vectors alog which the letters will spawn
        for(int i=0; i<spawnCols; i++)
        {
            for (int j = 0; j < spawnRows; j++)
            {
                spawnPoints[i, j] = Quaternion.AngleAxis(-spawnAngle * i, Vector3.up) * spawn_vec0;
                spawnPoints[i, j].y =+ spawnHeightOffset + j*spawnGapHeight;
                //Instantiate(spawnPointer, spawnPoints[i, j], Quaternion.identity);
                SpawnLetter(true, spawnPoints[i, j]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void SpawnLetter(bool upperCase, Vector3 spawnPosition)
    {
        letter_meshes letterScript = Letters[0].GetComponent<letter_meshes>();
        letterScript.SpawnLetter(upperCase, spawnPosition);
    }
}
