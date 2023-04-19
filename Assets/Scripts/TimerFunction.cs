using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFunction : MonoBehaviour
{
    private float timeValue;
    private float startTime;
    private float bestTime;
    private float prevBestTime;
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 0;
        startTime = Time.time;
        bestTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeValue = Time.time - startTime;
        GetComponent<TMP_Text>().text = "" + (int) timeValue;
    }

    public void SetBestTime()
    {
        if(bestTime == 0 || bestTime > timeValue - startTime)
        {
            prevBestTime = bestTime;
            bestTime = timeValue;
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
