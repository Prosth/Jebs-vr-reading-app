using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_shoot : MonoBehaviour
{
    public Transform shootAnchor;
    public GameObject bullet;


    public OVRInput.Button shootButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootButton, OVRInput.Controller.LTouch) || Input.GetButtonDown("Fire1") )
        {
            Instantiate(bullet, shootAnchor.position, shootAnchor.rotation);
        }
    }
}
