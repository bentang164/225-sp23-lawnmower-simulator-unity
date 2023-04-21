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
            GetComponent<TMP_Text>().text = "Time: " + (int)timeValue;
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
            }

        }
        else if (level.Equals("LevelTwo"))
        {
            if (DataTracker.LevelTwoBestTime == 0 || DataTracker.LevelTwoBestTime > timeValue)
            {
                DataTracker.LevelTwoPrevBestTime = DataTracker.LevelTwoBestTime;
                DataTracker.LevelTwoBestTime = timeValue;
            }

        }
        //Debug.Log("" + (int)LevelOneBestTime);
    }

    public void StopCounting()
    {
        stopCounting = true;
    }
}
