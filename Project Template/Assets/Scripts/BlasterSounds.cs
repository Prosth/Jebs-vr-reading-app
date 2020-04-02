using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlasterSounds : MonoBehaviour
{
    public List<AudioClip> blasterSound;
    AudioSource audioComponent;

    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
        audioComponent.Stop();
    }

    public void playRandomBlastSound()
    {
        audioComponent.Stop();
        AudioClip sound = blasterSound[Random.Range(0, blasterSound.Count)];
        audioComponent.PlayOneShot(sound);

    }
}
