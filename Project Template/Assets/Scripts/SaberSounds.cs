using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberSounds : MonoBehaviour
{
    public List<AudioClip> saberSound;
    AudioSource audioComponent;

    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
        audioComponent.Stop();
    }

    public void playRandomSaberSound()
    {
        audioComponent.Stop();
        AudioClip sound = saberSound[Random.Range(0, saberSound.Count)];
        audioComponent.PlayOneShot(sound);
    }
}

