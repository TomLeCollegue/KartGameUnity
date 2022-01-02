using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    public TimerManager timerManager;
    public HudBinding hudBinding;
    public KartController kartController;
    public Transform carTransform;
    public CheckPointsManager checkPointsManager;
    public ScoreManager scoreManager;

    public String pseudo = "Anonyme";


    public bool isGameStarted = false;

    void Start()
    {
        singleton = this;
        ResetGame();
        hudBinding.buttonPlay.onClick.AddListener(PlayButtonListener);
        hudBinding.retryButton.onClick.AddListener(RetryButtonListener);
    }

    public void FinishGame()
    {
        scoreManager.SendScore(pseudo, timerManager.timer);
        hudBinding.title.SetText(scoreManager.GetStringFromTimer(scoreManager.bestScore));
        ResetGame();
    }

    private void Update()
    {
        if(isGameStarted)
        {
            hudBinding.timer.SetText(string.Format("{0:00}:{1:00}:{2:000}", timerManager.minutes, timerManager.seconds, timerManager.milliSeconds));
        }
    }

    private void ResetGame()
    {
        isGameStarted = false;
        carTransform.position = new Vector3(0, 3, 0);
        carTransform.rotation = new Quaternion(0, 0, 0, 0);
        kartController.ResetCar();
        kartController.enabled = false;
        hudBinding.menuHUD.enabled = true;
        hudBinding.inGameHUD.enabled = false;

        timerManager.isTimerRunning = false;
        hudBinding.pseudoInputText.SetTextWithoutNotify(pseudo);
        scoreManager.FetchNewScores();
        hudBinding.scoreBoard.SetText(scoreManager.GetStringScoreBoard());
    }

    private void PlayButtonListener()
    {
        if(!isGameStarted)
        {
            hudBinding.menuHUD.enabled = false;
            hudBinding.inGameHUD.enabled = true;
            pseudo = hudBinding.pseudoInputText.text;
            StartCoroutine(CountDown());
        }
    }

    private void RetryButtonListener()
    {
        ResetGame();
    }

    IEnumerator CountDown()
    {
        hudBinding.countdown.SetText("3");
        yield return new WaitForSeconds(1f);
        hudBinding.countdown.SetText("2");
        yield return new WaitForSeconds(1f);
        hudBinding.countdown.SetText("1");
        yield return new WaitForSeconds(1f);
        hudBinding.countdown.SetText("");
        StartGame();
        yield return null;
    }

    private void StartGame()
    {
        isGameStarted = true;
        kartController.enabled = true;
        timerManager.isTimerRunning = true;
    }
}
