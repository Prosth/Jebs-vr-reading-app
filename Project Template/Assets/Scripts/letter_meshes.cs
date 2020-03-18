using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_meshes : MonoBehaviour
{

    public GameObject upperCaseMesh;
    public GameObject lowerCaseMesh;

    public GameObject letterPrefab;
    Transform spawnPoint;

    bool upperCase = false;

    public GameObject SpawnLetter(bool upperCase, Vector3 spawnPoint)
    {
        GameObject letter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity) as GameObject;

        upperCaseMesh.SetActive(upperCase);
        lowerCaseMesh.SetActive(!upperCase);

        return letter;
    }

}
