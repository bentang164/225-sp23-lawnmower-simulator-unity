using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Level1Button() {
        SceneManager.LoadScene("LevelOne");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("LevelTwo");
    }
}
