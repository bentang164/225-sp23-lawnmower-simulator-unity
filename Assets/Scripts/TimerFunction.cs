using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFunction : MonoBehaviour
{
    private float timeValue;
    private float startTime;
    private float bestTime = 0;
    private float prevBestTime;
    public static float LevelOnePrevBestTime = 0;
    public static float LevelTwoPrevBestTime = 0;

    public static float LevelOneBestTime = 0;
    public static float LevelTwoBestTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeValue = 0;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeValue = Time.time - startTime;
        GetComponent<TMP_Text>().text = "" + (int) timeValue;
    }

    public void SetBestTime(string level)
    {
        if(bestTime == 0 || bestTime > timeValue - startTime)
        {
            if (level.Equals("LevelOne"))
            {
                LevelOnePrevBestTime = bestTime;
                prevBestTime = bestTime;

                LevelOneBestTime = timeValue;
                bestTime = timeValue;
            } else if(level.Equals("LevelTwo"))
            {
                LevelTwoPrevBestTime = bestTime;
                prevBestTime = bestTime;

                LevelTwoBestTime = timeValue;
                bestTime = timeValue;
            }

            Debug.Log("" + (int)bestTime);
        }

       

    }

    public float GetBestTime()
    {
        float temp = bestTime;
        return temp;
    }

    public float GetPrevBestTime()
    {
        float temp = prevBestTime;
        return temp;
    }
}
