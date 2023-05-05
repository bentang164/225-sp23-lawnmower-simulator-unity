using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public string nextScene;

    public void playButton() {
        SceneManager.LoadScene(nextScene);
    }

    public void quitButton() {
        Application.Quit();
    }
}
