using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndLevelScript : MonoBehaviour
{
    public string level;
    TMP_Text prevBestText;
    TMP_Text bestText;

    // Start is called before the first frame update
    void Start()
    {
        prevBestText = GameObject.Find("PrevBestText").GetComponent<TMP_Text>();
        bestText = GameObject.Find("NewBestText").GetComponent<TMP_Text>();
        changeBestText(DataTracker.NewBestBool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene() {
        SceneManager.LoadScene(level);
    }

    public void changeBestText(bool NewBestBool)
    {
        if (NewBestBool)
        {
            if (DataTracker.CurrentLevelName.Equals("LevelOne"))
            {
                prevBestText.SetText("Previous Best: " + (int)DataTracker.LevelOnePrevBestTime);
                bestText.SetText("New Best: " + (int)DataTracker.LevelOneBestTime);
            }
            else if (DataTracker.CurrentLevelName.Equals("LevelTwo"))
            {
                prevBestText.SetText("Previous Best: " + (int)DataTracker.LevelTwoPrevBestTime);
                bestText.SetText("New Best: " + (int)DataTracker.LevelTwoBestTime);
            }
            else if (DataTracker.CurrentLevelName.Equals("LevelThree"))
            {
                prevBestText.SetText("Previous Best: " + (int)DataTracker.LevelThreePrevBestTime);
                bestText.SetText("New Best: " + (int)DataTracker.LevelThreeBestTime);
            }
        } else
        {
            bestText.SetText("");
            if (DataTracker.CurrentLevelName.Equals("LevelOne"))
            {  
                prevBestText.SetText("Current Best: " + (int)DataTracker.LevelOneBestTime);
            }
            else if (DataTracker.CurrentLevelName.Equals("LevelTwo"))
            {
                prevBestText.SetText("Current Best: " + (int)DataTracker.LevelThreeBestTime);
            }
            else if (DataTracker.CurrentLevelName.Equals("LevelThree"))
            {
                prevBestText.SetText("Current Best: " + (int)DataTracker.LevelThreeBestTime);
            }
        }
    }

}
