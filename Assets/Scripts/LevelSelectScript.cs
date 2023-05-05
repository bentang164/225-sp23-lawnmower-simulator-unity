using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{

    public void FreePlayButton() {
        SceneManager.LoadScene("FreePlay");
    }

    public void Level1Button()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("LevelThree");
    }
}
