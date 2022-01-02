using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public float timer = 0f;
    public bool isTimerRunning = false;

    public int minutes;
    public int seconds;
    public int milliSeconds;

    // Update is called once per frame
    void Update()
    {
        if(isTimerRunning)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0f;
        }
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        milliSeconds = Mathf.FloorToInt((timer % 1) * 1000);
    }
}
