using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_meshes : MonoBehaviour
{

    public GameObject upperCaseMesh;
    public GameObject lowerCaseMesh;

    public GameObject letterPrefab;
    Transform spawnPoint;

    private Vector3 defaultScale = new Vector3(1f, 1f, 1f);

    bool upperCase = false;

    //SPAWN A LETTER WITH THE CHOSEN CASE
    public GameObject SpawnLetter(bool upperCase, Vector3 spawnPoint, Vector3 spawnScale)
    {
        GameObject spawnedletter = Instantiate(letterPrefab, spawnPoint, Quaternion.identity) as GameObject;
        spawnedletter.transform.localScale = spawnScale;
        upperCaseMesh.SetActive(upperCase);
        lowerCaseMesh.SetActive(!upperCase);
        Debug.Log("entered  letter script"+ spawnScale);
        return spawnedletter;
    }

}
