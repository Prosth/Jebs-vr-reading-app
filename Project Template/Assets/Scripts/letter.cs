using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{

    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blade" || other.tag == "Bullet_Player")
        {
            Instantiate<GameObject>(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


}
