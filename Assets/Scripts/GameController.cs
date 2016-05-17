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

    public static string[] questions;
    public static string[] answers;

    public static int currentEnemyId;

    public static string getQuestion(string answer)
    {
        int index = Array.FindIndex(answers, item => item.Equals(answer));
        if (index != -1)
        {
            return questions[index];
        }
        return "";
    }

    public static string getAnswer(string question)
    {
        return answers[Array.FindIndex(questions, item => item.Equals(question))];
    }

    void Start()
    {
        //init questions and answers
        int savedScore = 100; //TODO: load current score in file
        if (savedScore < 1000)
        {
            questions = new [] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ" };
            answers = new [] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko" };
        }

        //init ui
        score = 0;
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScoreText();
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
