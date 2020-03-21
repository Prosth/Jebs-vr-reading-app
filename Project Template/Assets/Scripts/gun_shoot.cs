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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (null != anim)
        {
            Debug.Log("empty animator");
        }
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch)>0.3f || Input.GetButtonDown("Fire1") )
        {
            Instantiate(bullet, shootAnchor.position, shootAnchor.rotation);
            Instantiate(flash, shootAnchor.position, shootAnchor.rotation);
           anim.Play("pistolKick");
        }
    }
}
