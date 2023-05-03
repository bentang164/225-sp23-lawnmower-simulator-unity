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
        float currLevelBest = DataTracker.BestTimes[level];

        if (currLevelBest == 0 || currLevelBest > timeValue) {
            DataTracker.PrevBestTimes[level] = currLevelBest;
            DataTracker.BestTimes[level] = timeValue;
            DataTracker.NewBestBool = true;
        } else {
            DataTracker.NewBestBool = false;
        }

    }

    public void StopCounting()
    {
        stopCounting = true;
    }
}
