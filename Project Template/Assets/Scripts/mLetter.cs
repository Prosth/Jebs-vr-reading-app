using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mLetter : MonoBehaviour
{

    private MLetterManager mletterManager;
    private Vector3 startPosition; 

    public MLetterManager mLettermanager
    {
        set { mletterManager = value; }
    }

    public void InitLetter()
    {
        //INITIALISE 
        Activate();
        //GET COMPONENTS
        //ENABLE DISSABLE STUFF
    }


    public void Reset()
    {
        // ADD TO INACTIVE LETTER LIST
        mletterManager.InactiveLetters.Enqueue(this);

        //DISABLE LETTER
        gameObject.SetActive(false);
    }


    public void Activate()
    {
        //ENABLE LETTER
        gameObject.SetActive(true);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
