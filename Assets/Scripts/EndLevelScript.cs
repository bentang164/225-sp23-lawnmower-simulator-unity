using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndLevelScript : MonoBehaviour
{
    public string level;
    TMP_Text prevBestText = GameObject.Find("PrevBestText").GetComponent<TMP_Text>();
    TMP_Text bestText = GameObject.Find("NewBestText").GetComponent<TMP_Text>();

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
            prevBestText.SetText("Previous Best: " + (int)DataTracker.LevelOnePrevBestTime);
            bestText.SetText("New Best: " + (int)DataTracker.LevelOneBestTime);
        } else if (DataTracker.CurrentLevelName.Equals("LevelTwo"))
        {
            prevBestText.SetText("Previous Best: " + (int)DataTracker.LevelTwoPrevBestTime);
            bestText.SetText("New Best: " + (int)DataTracker.LevelTwoBestTime);
        }
    }

}
