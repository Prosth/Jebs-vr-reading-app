using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{

    public GameObject explosion;
    private bool wasGrabbed = false;

    letter_audio audioScript;
    OVRGrabbable grabScript;
    public string whatLetter;

    private bool was_grabbed_before = false;

    private LetterManager letter_manager;

    public LetterManager letter_Manager
    {
        set { letter_manager = value; }
    }


    public void Reset()
    {

    }

    void Start()
    {
        initLetter();
    }


    private void Update()
    {

        if (grabScript != null)
        {
            if (grabScript.isGrabbed && !was_grabbed_before)
            {
                was_grabbed_before = true;
                audioScript.playIntroSound();
            }
            if (!grabScript.isGrabbed)
            {
                was_grabbed_before = false;
                audioScript.stopSound();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade" || other.tag == "Bullet_Player")
        {
            Instantiate<GameObject>(explosion, transform.position, Quaternion.identity);         
            audioScript.playDestroySound();
            SpawnPointScript parentscript = transform.parent.gameObject.GetComponent("SpawnPointScript") as SpawnPointScript;
            if(whatLetter == parentscript.currentLetterStr)
            {
                parentscript.PlayGoodHitSound();
            }
            if (whatLetter != parentscript.currentLetterStr)
            {
                parentscript.PlayBadHitSound();
            }
            Destroy(gameObject);
        }
    }

    public void initLetter()
    {
        // Get Components
        audioScript = gameObject.GetComponent("letter_audio") as letter_audio;
        grabScript = gameObject.GetComponent("OVRGrabbable") as OVRGrabbable;
    }

}




