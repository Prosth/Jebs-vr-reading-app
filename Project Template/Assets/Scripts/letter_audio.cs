using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter_audio : MonoBehaviour
{
    public AudioClip audioLetterName;
    public AudioClip audioLetterSound;
    public AudioClip audioLetterCase;
    public AudioClip audioLetterIntro;
    public AudioClip audioLetterDestroy;

    AudioSource audioComponent;

    // Start is called before the first frame update
    void Start()
    {
        audioComponent = GetComponent<AudioSource>();
       
    }

    public void playIntroSound()
    {
            audioComponent.Stop();
            audioComponent.PlayOneShot(audioLetterIntro);
    }


    public void playDestroySound()
    {
            audioComponent.Stop();
            audioComponent.PlayOneShot(audioLetterDestroy);
    }

    public void stopSound()
    {
        audioComponent.Stop();

    }
}
