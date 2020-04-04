using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCannon : MonoBehaviour
{
    
    public GameObject letterSpawner;
    public GameObject shootPosition;


    private GameObject lvlPicker;
    private GameObject lvlManager;

    private letter_spawner letterSpawnScript;
    private level_manager mngScript;
    private LevelPicker lvlPickerScript;

    [SerializeField]
    float shootingForce = 5f;

    [Range(0.1f, 10f)]
    [SerializeField]
    float shootingHight;

    [SerializeField]
    float minShootInterval = 3;

    [SerializeField]
    float maxShootInterval = 7;

    private float currentShootInterval = 4;

    private int currentLetterInt =1;

    private float startTime;
    private float countdownBeforeStartShootig = 5f;
    private bool startShooting = false;
    private float lastShotTime = 0f;

    private string lvlLetter;

    // Start is called before the first frame update
    void Start()
    {
        lvlManager = GameObject.Find("Level_Manager");

        lvlPicker = GameObject.Find("Level_Manager/LevelPicker");

        //GET LEVEL MANAGER SCRIPT
        mngScript = lvlManager.GetComponent("level_manager") as level_manager;

        //GET LETTER SPAWNER SCRIPT
        letterSpawnScript = letterSpawner.GetComponent("letter_spawner") as letter_spawner;

        //GET THE CURRENT CORRECT LETTER FOR THE LEVEL FROM LEVEL MANAGER                  
        currentLetterInt = mngScript.currentLetterInt;

        //INIT START TIME AND FIRST RANDOM INTERVAL
        startTime = Time.time;
        currentShootInterval = Random.Range(minShootInterval, maxShootInterval);

       // Debug.Log("CURRENT CANNON LETTER IS: "+ currentLetterInt + lvlLetter);

    }


    void Update()
    {        
        //SHOOT IF X IS PRESSED - FOR TESTING
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootLetter(currentLetterInt, true);
            Debug.Log("letter shot");
        }

        //WAIT FOR COUNTDOWN BEFORE STARTING
        if(Time.time - startTime >= countdownBeforeStartShootig)
        {
            startShooting = true;

        }
        //SHOOT
        if (startShooting)
        {
            if (Time.time - lastShotTime  >= currentShootInterval)
            {
                int letterToShoot = Random.Range(0,3);
                ShootLetter(letterToShoot, true);
                currentShootInterval = Random.Range(minShootInterval, maxShootInterval);
                lastShotTime = Time.time;
            }
        }
    }


    void ShootLetter(int letter, bool letterCase)
    {
        float letterScale = 1.8f;
        letter_meshes letterMeshesScript = letterSpawnScript.Letters[letter].GetComponent<letter_meshes>();

        GameObject letter_clone = letterMeshesScript.SpawnLetter(true, shootPosition.transform.position, shootPosition.transform.rotation.eulerAngles, new Vector3(1,1,1)* letterScale);

        Rigidbody rb = letter_clone.GetComponent<Rigidbody>();
        rb.useGravity = true;
        Vector3 forceVec = gameObject.transform.forward *-1;

        forceVec.y += shootingHight;

        Debug.Log("vector" + forceVec);
        rb.AddForce(forceVec.normalized * shootingForce, ForceMode.Impulse);
       
        Destroy(letter_clone, 3);
    }
}
