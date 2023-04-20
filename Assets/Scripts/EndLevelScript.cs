using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndLevelScript : MonoBehaviour
{
    public string level;
    
    // Start is called before the first frame update
    void Start()
    {
        changeBestText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene() {
        SceneManager.LoadScene(level);
    }

    public void changeBestText()
    {
        if (DataTracker.CurrentLevelName.Equals("LevelOne"))
        {
            GameObject.Find("PrevBestText").GetComponent<TMP_Text>().SetText("Previous Best: " + (int)DataTracker.LevelOnePrevBestTime);
            GameObject.Find("NewBestText").GetComponent<TMP_Text>().SetText("New Best: " + (int)DataTracker.LevelOneBestTime);
        } else if (DataTracker.CurrentLevelName.Equals("LevelTwo"))
        {
            GameObject.Find("PrevBestText").GetComponent<TMP_Text>().SetText("Previous Best: " + (int)DataTracker.LevelTwoPrevBestTime);
            GameObject.Find("NewBestText").GetComponent<TMP_Text>().SetText("New Best: " + (int)DataTracker.LevelTwoBestTime);
        }
    }

}
