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

    public int enemyCount;
    public float waveWait;
    public float spawnWait;
    public float firstWait;
    public Text scoreText;
    private int score;

    private bool gameOver;
    private bool restart;

    public Text gameOverText;
    public Text restartText;

    public static int currentEnemyId;

    public static Level currentLevel;

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
        int savedScore = 100; //TODO: load current score in file
        int savedLevelIndex = 0; //TODO: load saved level index in file

        //load level from saved data
        currentLevel = LevelUtil.GetLevel(savedLevelIndex);

        //init ui
        score = savedScore;
        UpdateScoreText();

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
        yield return new WaitForSeconds(firstWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
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
        UpdateScoreText();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void MinusScore(int scoreToMinus)
    {
        score -= scoreToMinus;
        UpdateScoreText();
    }
}
