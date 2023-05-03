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
        string level = DataTracker.CurrentLevelName;
        if (NewBestBool)
        {
            prevBestText.SetText("Previous Best: " + (int) DataTracker.PrevBestTimes[level]);
            bestText.SetText("New Best: " + (int) DataTracker.BestTimes[level]);
        } else
        {
            bestText.SetText("");
            prevBestText.SetText("Current Best: " + (int) DataTracker.BestTimes[level]);
        }
    }

}
