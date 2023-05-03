using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFunction : MonoBehaviour
{
    private float timeValue;
    private float startTime;
    private bool stopCounting;

    // Start is called before the first frame update
    void Start()
    {
        stopCounting = false;
        timeValue = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopCounting)
        {
            timeValue = Time.time - startTime;
            GetComponent<TMP_Text>().text = "" + (int)timeValue;
        }
    }

    public void SetBestTime()
    {
        string level = DataTracker.CurrentLevelName;
        if (level.Equals("LevelOne"))
        {
            if (DataTracker.LevelOneBestTime == 0 || DataTracker.LevelOneBestTime > timeValue)
            {
                DataTracker.LevelOnePrevBestTime = DataTracker.LevelOneBestTime;
                DataTracker.LevelOneBestTime = timeValue;
                DataTracker.NewBestBool = true;
            } else
            {
                DataTracker.NewBestBool = false;
            }

        }
        else if (level.Equals("LevelTwo"))
        {
            if (DataTracker.LevelTwoBestTime == 0 || DataTracker.LevelTwoBestTime > timeValue)
            {
                DataTracker.LevelTwoPrevBestTime = DataTracker.LevelTwoBestTime;
                DataTracker.LevelTwoBestTime = timeValue;
                DataTracker.NewBestBool = true;
            } else
            {
                DataTracker.NewBestBool = false;
            }

        } 
        else if (level.Equals("LevelThree"))
        {
            if (DataTracker.LevelThreeBestTime == 0 || DataTracker.LevelThreeBestTime > timeValue)
            {
                DataTracker.LevelThreePrevBestTime = DataTracker.LevelThreeBestTime;
                DataTracker.LevelThreeBestTime = timeValue;
                DataTracker.NewBestBool = true;
            }
            else
            {
                DataTracker.NewBestBool = false;
            }

        }
    }

    public void StopCounting()
    {
        stopCounting = true;
    }
}
