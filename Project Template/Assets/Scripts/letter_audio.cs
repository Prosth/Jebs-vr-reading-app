using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_audio : MonoBehaviour
{
    public AudioClip audioLetterName;
    public AudioClip audioLetterSound;
    public AudioClip audioLetterCase;

    AudioSource audioComponent;

    // Start is called before the first frame update
    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
        playSound(audioLetterName);
    }

    void playSound(AudioClip sound)
    {
        if (sound)
        {
            audioComponent.PlayOneShot(sound);
        }
    }
}
