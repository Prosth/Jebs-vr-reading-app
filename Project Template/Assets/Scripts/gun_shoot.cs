using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_shoot : MonoBehaviour
{
    public Transform shootAnchor;
    public GameObject bullet;
    public GameObject flash;

    Animator anim;
    public OVRInput.Button shootButton;

    private bool stickDownLast = false;

    new BlasterSounds audio;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent("BlasterSounds") as BlasterSounds;
    }

    // Update is called once per frame
    void Update()
    {

        //check for animator
        if (null == anim)
        {
            Debug.Log("empty animator");
        }

        //Check which hand is holding this blaster
       if (gameObject.name == "SciFiHandGun_Right")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                Instantiate(bullet, shootAnchor.position, shootAnchor.rotation);
                Instantiate(flash, shootAnchor.position, shootAnchor.rotation);
                anim.Play("pistolKick");
                audio.playRandomBlastSound();
            }
        }


        if (gameObject.name == "SciFiHandGun_Left")
        {
            if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
            {
                Instantiate(bullet, shootAnchor.position, shootAnchor.rotation);
                Instantiate(flash, shootAnchor.position, shootAnchor.rotation);
                anim.Play("pistolKick");
                audio.playRandomBlastSound();
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            
                audio.playRandomBlastSound();

            
        }


    }
}
