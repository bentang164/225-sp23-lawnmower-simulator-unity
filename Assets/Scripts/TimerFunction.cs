using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerFunction : MonoBehaviour
{
    public float timeValue;
    public float startTime;
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
}
