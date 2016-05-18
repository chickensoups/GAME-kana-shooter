using System;
using UnityEngine;
using System.Collections;
using System.Timers;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValue;
    public GameObject enemy;

    private int score;
    public Text scoreText;

    public Text currentLevelText;
    public Text nextLevelText;

    private float newWaveCooldown;
    private float newWaveCooldownRate;
    private float nextNewWaveUpdateTime;
    public Text newWaveIsCommingText;
    public Text newWaveCooldownText;

    private bool gameOver;
    public Text gameOverText;

    private bool restart;
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
        int savedScore = 50; //TODO: load current score in file
        int savedLevelIndex = 0; //TODO: load saved level index in file

        //load level from saved data
        currentLevel = LevelUtil.GetLevel(savedLevelIndex);
        nextLevel = LevelUtil.GetLevel(savedLevelIndex + 1);

        //init ui
        score = savedScore;
        UpdateScore();

        newWaveCooldown = 0;
        newWaveCooldownRate = 0.1f;
        nextNewWaveUpdateTime = Time.time;
        newWaveCooldownText.text = "";
        newWaveIsCommingText.text = ""; 

        gameOver = false;
        gameOverText.text = "";

        restart = false;
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

        if (newWaveCooldown > 0)
        {
            newWaveCooldown -= Time.deltaTime;
            if (Time.time > nextNewWaveUpdateTime)
            {
                UpdateNewWaveCooldownText();
            }
        }
    }

    private void UpdateNewWaveCooldownText()
    {
        if (newWaveCooldown <= newWaveCooldownRate)
        {
            newWaveCooldown = 0;
            newWaveCooldownText.text = "";
            newWaveIsCommingText.text = "";
        }
        else
        {
            newWaveCooldownText.text = "" + Math.Round(newWaveCooldown, 2);
        }
        nextNewWaveUpdateTime += newWaveCooldownRate;
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
            //set new wave text
            newWaveIsCommingText.text = "New wave is comming!!!";
            newWaveCooldown = currentLevel.GetWaveWait();
            nextNewWaveUpdateTime = Time.time;
            yield return new WaitForSeconds(currentLevel.GetWaveWait());
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
        if (score < currentLevel.GetDownPoint() || score > currentLevel.GetUpPoint())
        {
            //clear all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            if (score < currentLevel.GetDownPoint())
            {
                currentLevel = LevelUtil.DownLevel(currentLevel);
                //animation when level down
                StartCoroutine(MainLightController.LightDown());
            }
            else if (score > currentLevel.GetUpPoint())
            {
                currentLevel = LevelUtil.UpLevel(currentLevel);
                //animation when level up
                StartCoroutine(MainLightController.LightUp());
            }
        }
        nextLevel = LevelUtil.GetLevel(currentLevel.GetIndex() + 1);
        UpdateCurrentLevelText();
        UpdateNextLevelText();
    }

    private void UpdateCurrentLevelText()
    {
        currentLevelText.text = currentLevel.GetName();
    }

    private void UpdateNextLevelText()
    {
        nextLevelText.text = "Next Level: " + (nextLevel.GetDownPoint() - score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
