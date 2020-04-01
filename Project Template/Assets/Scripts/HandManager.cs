using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject L_Hand;
    public GameObject L_Blaster;
    public GameObject L_Saber;

    public GameObject R_Hand;
    public GameObject R_Blaster;
    public GameObject R_Saber;


    AudioSource equipAudio;



    void Start()
    {
        initEquipedHands();
        equipAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //CHECK FOR BUTTON DOWN A OR X
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //PLAY EQUIP SOUND
            equipAudio.Stop();
            equipAudio.Play();
            //IF WAS IN HAND MODE, RESET TO DEFAULT
            if (R_Hand.activeSelf)
            {
                initEquipedHands();
            }
            else //IF WAS NOT IN HAND MODE, SWITCH SABER WITH BLASTER
            {
                R_Hand.SetActive(false);
                R_Blaster.SetActive(!R_Blaster.activeSelf);
                R_Saber.SetActive(!R_Saber.activeSelf);
            }
        }
        //SAME AS ABOVE
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            equipAudio.Stop();
            equipAudio.Play();
            if (L_Hand.activeSelf)
            {
                initEquipedHands();
            }
            else
            {
                L_Hand.SetActive(false);
                L_Blaster.SetActive(!L_Blaster.activeSelf);
                L_Saber.SetActive(!L_Saber.activeSelf);
            }           
        }
        //----------SWITCH TO HANDS MODE IF SECOND TOUCH BUTTON PRESSED (Y or B)---
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            equipAudio.Stop();
            equipAudio.Play();
            R_Hand.SetActive(true);
            R_Blaster.SetActive(false);
            R_Saber.SetActive(false);
        }
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            equipAudio.Stop();
            equipAudio.Play();
            L_Hand.SetActive(true);
            L_Blaster.SetActive(false);
            L_Saber.SetActive(false);
        }   
    }

    void initEquipedHands()
    {
        //SET DEFAULT LEFT HAND EQUIPMENT 
        L_Hand.SetActive(false);
        L_Blaster.SetActive(false);
        L_Saber.SetActive(true);

        //SET DEFAULT RIGHT HAND EQUIPMENT 
        R_Hand.SetActive(false);
        R_Blaster.SetActive(true);
        R_Saber.SetActive(false);
    }

}
