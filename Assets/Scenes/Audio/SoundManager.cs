using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    void Start()
    {
        // Ambient sounds
        soundFX[0].Play();
        soundFX[2].Play();
    }


    // Array that holds sound tracks
    public AudioSource[] soundFX;
    //public PauseMenuScript pauseMenuScript1;

    void Update()
    {
        // If arrow keys are being pressed
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) 
        {
            soundFX[2].Stop();
            
            if(!soundFX[1].isPlaying) 
            {
                soundFX[1].Play();
            }
        }
        else 
        {
            soundFX[1].Stop();
            
            if(!soundFX[2].isPlaying) 
            {
                soundFX[2].Play();
            }
        }


        // if (pauseMenuScript1.GetComponent<pauseMenuScript1>().ActiveState() == true) {
        //     soundFX[0].Stop();
        //     soundFX[1].Stop();
        //     soundFX[2].Stop();
        // }
    }
}
