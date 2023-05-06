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
            //Time.time grabs the total time since application start, so we need to offset it
            timeValue = Time.time - startTime;
            GetComponent<TMP_Text>().text = ((int)timeValue).ToString();
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

    //When the completion threshold is reached, this function is called by DetectCompletion.cs to stop the timer
    public void StopCounting()
    {
        stopCounting = true;
    }
}
