using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{

    public GameObject explosion;
    private bool isItGrabbed = false;

    letter_audio audioScript;
    OVRGrabbable disGrabScript;
    public string whatLetter;

    void Start()
    {
        audioScript = gameObject.GetComponent("letter_audio") as letter_audio;
        disGrabScript = gameObject.GetComponent("DistanceGrabbable") as OVRGrabbable;
    }


    private void Update()
    {
        if (disGrabScript != null)
        {
            if ((disGrabScript.isGrabbed) || (isItGrabbed = !disGrabScript.isGrabbed))
            {
                audioScript.playSound(audioScript.audioLetterIntro);
            }
            isItGrabbed = disGrabScript.isGrabbed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade" || other.tag == "Bullet_Player")
        {
            Instantiate<GameObject>(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
