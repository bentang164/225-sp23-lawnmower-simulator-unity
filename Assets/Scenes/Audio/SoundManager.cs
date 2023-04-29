using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Array that holds sound tracks
    // 0: Spring sounds    1: Mowing sound    2: Idling mower sound
    public AudioSource[] soundFX;


    void Start()
    {
        // Play ambient sound tracks on start
        soundFX[0].Play();
        soundFX[2].Play();
    }


    void Update()
    {
        // If arrow keys are being pressed:
        // Stop the idling mower sounds &
        // Play the mowing sound (if it's not already playing)
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
    }
}
