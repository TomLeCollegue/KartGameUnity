using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public Dictionary<string, float> scoreBoard = new Dictionary<string, float>();

    public float bestScore;

    public void FetchNewScores()
    {
        if(scoreBoard.Count == 0)
        {
            scoreBoard.Add("Tom", 100);
            scoreBoard.Add("Hugo", 200);
            scoreBoard.Add("Sam", 300);
        }
    }

    public void SendScore(string pseudo, float timer)
    {
        if (timer < bestScore)
        {
            bestScore = timer;
        }
        scoreBoard.Add(pseudo, timer);
    }

    public string GetStringScoreBoard()
    {
        string result = "";
        foreach (KeyValuePair<string, float> entry in scoreBoard)
        {
            result += entry.Key + " : " + GetStringFromTimer(entry.Value) + "\n";
        }

        return result;
    }

    public string GetStringFromTimer(float timer)
    {
        var minutes = Mathf.FloorToInt(timer / 60);
        var seconds = Mathf.FloorToInt(timer % 60);
        var milliSeconds = Mathf.FloorToInt((timer % 1) * 1000);

        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}
