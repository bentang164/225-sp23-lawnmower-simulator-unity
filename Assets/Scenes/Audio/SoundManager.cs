using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        soundFX[0].Play();
        soundFX[2].Play();
    }

    public AudioSource[] soundFX;

    // Update is called once per frame
    void Update()
    {
        // Player input via arrow keys or wasd
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

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
