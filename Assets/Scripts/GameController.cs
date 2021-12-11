using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private FadeEffect[] fadeGameStart;
    [SerializeField]
    private GameObject panalGameStart;
    [SerializeField]
    private GameObject panaelGameOver;
    [SerializeField]
    private float timeStopTime;
    [SerializeField]
    private TextMeshProUGUI textInGameScore;
    [SerializeField]
    private TextMeshProUGUI textGameOverScore;
    [SerializeField]
    private TextMeshProUGUI textGameOverBestScore;
    [SerializeField]
    private TextMeshProUGUI textGameStartBestScore;
    private int currentScore = 0;
    public bool IsGameStart { private set; get; } = false;
    public bool IsGameOver { private set; get; } = false;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        Time.timeScale = 1f;
        int bestScore = PlayerPrefs.GetInt("BestScore");
        textGameStartBestScore.text = bestScore.ToString();

        for (int i = 0; i < fadeGameStart.Length; ++i)
        {
            fadeGameStart[i].FadeIn();
        }
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
                IsGameStart = true;
                yield break;
            }
            yield return null;
        }
        
    }

    public void GameStart()
    {
        panalGameStart.SetActive(false);
        textInGameScore.gameObject.SetActive(true);
    }
    public void IncreaseScore(int score = 1)
    {
        currentScore += score;
        textInGameScore.text = currentScore.ToString();
    }
    public void GameOver()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            textGameOverBestScore.text = currentScore.ToString();
        }
        else
        {
            textGameOverBestScore.text = bestScore.ToString();
        }
        IsGameOver = true;
        panaelGameOver.SetActive(true);
        textGameOverScore.text = currentScore.ToString();
        textInGameScore.gameObject.SetActive(false);
        StartCoroutine("SlowAndStopTime");
    }
    private IEnumerator SlowAndStopTime()
    {
        float current = 0;
        float percent = 0;
        Time.timeScale = 0.5f;
        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / timeStopTime;
            yield return null;
        }
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
