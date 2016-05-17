using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValue;
    public GameObject enemy;

    public Text scoreText;
    public Text CurrentLevelText;
    public Text NextLevelText;

    private int score;

    private bool gameOver;
    private bool restart;

    public Text gameOverText;
    public Text restartText;

    public static int currentEnemyId;

    public static Level currentLevel;

    private Level nextLevel;

    public static string GetQuestion(string answer)
    {
        int index = currentLevel.GetAnswers().IndexOf(answer);
        if (index != -1)
        {
            return currentLevel.GetQuestions()[index];
        }
        return "";
    }

    public static string GetAnswer(string question)
    {
        int index = currentLevel.GetQuestions().IndexOf(question);
        if (index != -1)
        {
            return currentLevel.GetAnswers()[index];
        }
        return "";
    }

    void Start()
    {

        //init level data
        LevelUtil.Init();
        //load saved data
        int savedScore = 80; //TODO: load current score in file
        int savedLevelIndex = 0; //TODO: load saved level index in file

        //load level from saved data
        currentLevel = LevelUtil.GetLevel(savedLevelIndex);
        nextLevel = LevelUtil.GetLevel(savedLevelIndex + 1);

        //init ui
        score = savedScore;
        UpdateScore();

        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        //start spawn enemy
        StartCoroutine(SpawnWave());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                restart = false;
                gameOver = false;
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            for (int i = 0; i < currentLevel.GetEnemyEachWaveCount(); i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(currentLevel.GetSpawnWait());
            }
            yield return new WaitForSeconds(currentLevel.GetSpawnWait());
            if (gameOver)
            {
                restart = true;
                restartText.text = "Press 'R' to restart!";
                break;
            }
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScore();
    }

    public void MinusScore(int scoreToMinus)
    {
        score -= scoreToMinus;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
    }

    private void UpdateScore()
    {
        UpdateScoreText();
        if (score < currentLevel.GetDownPoint())
        {
            currentLevel = LevelUtil.DownLevel(currentLevel);
        }
        else if (score > currentLevel.GetUpPoint())
        {
            currentLevel = LevelUtil.UpLevel(currentLevel);
        }
        nextLevel = LevelUtil.GetLevel(currentLevel.GetIndex() + 1);
        UpdateCurrentLevelText();
        UpdateNextLevelText();
    }

    private void UpdateCurrentLevelText()
    {
        CurrentLevelText.text = currentLevel.GetName();
    }

    private void UpdateNextLevelText()
    {
        NextLevelText.text = "Next Level: " + (nextLevel.GetDownPoint() - score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
