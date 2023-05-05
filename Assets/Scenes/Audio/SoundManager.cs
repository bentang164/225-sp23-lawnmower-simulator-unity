using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Array that holds sound tracks
    // 0: Spring sounds    1: Mowing sound    2: Idling mower sound
    public AudioSource[] soundFX;
    
    private bool gameIsPaused;



    void Start()
    {
        gameIsPaused = false;

        // Play ambient sound tracks on start
        soundFX[0].Play();
        soundFX[2].Play();
    }

    void Update()
    {
        if (gameIsPaused) {
            soundFX[0].Stop();
            soundFX[1].Stop();
            soundFX[2].Stop();
        }
        // If arrow keys are being pressed: stop idling mower sound & play mowing sound
        else if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) {
            soundFX[2].Stop();
            
            if(!soundFX[1].isPlaying) {
                soundFX[1].Play();
            }
        }
        else {
            soundFX[1].Stop();
            
            if(!soundFX[2].isPlaying) {
                soundFX[2].Play();
            }
        }
    }


    //Called when the pause menu gets opened
    public void PauseSounds() {
        gameIsPaused = true;
    }

    //Called when the pause menu gets closed
    public void ResumeSounds() {
        gameIsPaused = false;
    }
}
