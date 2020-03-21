using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{

    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade")
        {
            Instantiate<GameObject>(explosion, transform.position, Quaternion.identity);
        }
    }


}
