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
                PlayShoot(true);
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
                PlayShoot(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            
                audio.playRandomBlastSound();

            
        }

         void PlayShoot(bool rightHanded)
        {
            if (rightHanded) StartCoroutine(Haptics(0.8f, 0.7f, 0.3f, true, false));
            else StartCoroutine(Haptics(0.8f, 0.7f, 0.3f, false, true));
        }


        IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
        {
            if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
            if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

            yield return new WaitForSeconds(duration);

            if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }

    }
}
