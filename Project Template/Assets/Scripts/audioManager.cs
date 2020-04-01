using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip AnnounceLetterGoal;
    public AudioClip AnnounceVictory;
    public AudioClip AnnounceFail;
    public AudioClip wrongHit;

    AudioSource audioComponent;

    // Start is called before the first frame update
    void Start()
    {
        audioComponent = GetComponent<AudioSource>();

    }

    public void playSound(AudioClip sound)
    {
        if (sound)
        {
            audioComponent.PlayOneShot(sound);
        }


    }
}
