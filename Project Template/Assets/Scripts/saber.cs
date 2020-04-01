using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saber : MonoBehaviour
{

    new SaberSounds audio;

    private float lastPlayedTime = 0f;
    // Start is called before the first frame update

    void Start()
    {
        audio = GetComponent("SaberSounds") as SaberSounds;
    }


    private void Update()
    {        
        //CHECK which hand saber this is
        if (gameObject.name == "Saber_Right")
        {         
            //CHECK CONTROLLER VELOCITY FOR SOUND FX
            if (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch).magnitude >= 1.00f || OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.RTouch).magnitude >= 3.50f)
            {
                if(Time.time - lastPlayedTime >= 2f){
                    audio.playRandomSaberSound();
                    lastPlayedTime = Time.time;
                }               
            }
        }

        if (gameObject.name == "Saber_Left")
        {           
            if (OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch).magnitude >= 1.00f || OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch).magnitude >= 3.50f)
            {
                if (Time.time - lastPlayedTime >= 2f)
                {
                    audio.playRandomSaberSound();
                    lastPlayedTime = Time.time;
                }              
            }
        }
    }     

}
