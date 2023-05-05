using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public string playGame;

    void Start()
    {
        
    }

    void Update()
    {
       
    }

    public void playButton() {
        SceneManager.LoadScene(playGame);
    }

    public void quitButton() {
        Application.Quit();
    }
}
