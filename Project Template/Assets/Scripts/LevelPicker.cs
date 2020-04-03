using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPicker : MonoBehaviour
{
    level_manager mngScript;
    public string letterLvl;
    public GameObject mng;


    //GET THE SCRIPT COMPONENT OF THE LVL MANAGER
    private void Start()
    {
        mngScript = mng.GetComponent("level_manager") as level_manager;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            SceneManager.LoadScene("Main_Hub");
        }
            
    }

        private void OnTriggerEnter(Collider other)
    {
        //CHECK FOR LETTER OR RESTART/HOME OBJ PLACED ON THE PICKER
        if(other.tag == "Letter_Normal")
        {
            letter letterScript = other.GetComponent("letter") as letter;
            letterLvl = letterScript.whatLetter;
            mngScript.letterLvl = letterLvl;
            SceneManager.LoadScene("Letter_Room_Teach");
        }

        if (other.tag == "Restart_Level")
        {
            SceneManager.LoadScene("Letter_Room_Teach");
        }

        if (other.tag == "Main_Menu")
        {
            mngScript.letterLvl = "main";
            SceneManager.LoadScene("Main_Hub");
        }

    }
}
