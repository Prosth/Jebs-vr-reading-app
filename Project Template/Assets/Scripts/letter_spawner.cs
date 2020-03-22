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



    public void CreateGrid(int spawnCols, int spawnRows, float spawnDistance, int letter, float spawnArchAngle = 140, float spawnHeightOffset = 0.5f ,float spawnGapHeight = 0.5f)
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
        for (int i = 0; i < spawnCols; i++)
        {
            for (int j = 0; j < spawnRows; j++)
            {
                spawnPoints[i, j] = Quaternion.AngleAxis(-spawnAngle * i, Vector3.up) * spawn_vec0;
                spawnPoints[i, j].y = +spawnHeightOffset + j * spawnGapHeight;

                SpawnLetter(letter, true, spawnPoints[i, j]);
                Debug.Log("entered spawn loop phase");
            }
        }
    }


    void SpawnLetter(int letter, bool upperCase, Vector3 spawnPosition)
    {
        Debug.Log("entered spawn letter phase");
        letter_meshes letterScript = Letters[letter].GetComponent<letter_meshes>();
        letterScript.SpawnLetter(upperCase, spawnPosition);
    }




}
