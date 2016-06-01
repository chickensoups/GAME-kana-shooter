using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

    public Text welcomeMessageText;

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

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.level = currentLevel.GetIndex();
        data.score = score;

        bf.Serialize(file, data);
        file.Close();
    }

    public PlayerData Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat");

            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();
            return data;
        }
        return null;
    }

    void Start()
    {

        //init level data
        LevelUtil.Init();
        //load saved data
        PlayerData savedData = Load();
        if (savedData != null)
        {
            //load level and score depend on saved data
            currentLevel = LevelUtil.GetLevel(savedData.level);
            nextLevel = LevelUtil.GetLevel(savedData.level + 1);
            score = savedData.score;
        }
        else
        {
            //load level and score depend on saved data
            currentLevel = LevelUtil.GetLevel(1);
            nextLevel = LevelUtil.GetLevel(2);
            score = 0;
        }

        //display welcome message
        StartCoroutine(DisplayWelcomeMessage());
        //Update Score first time
        UpdateScore();

        newWaveCooldown = 0;
        newWaveCooldownRate = 0.1f;
        nextNewWaveUpdateTime = Time.time;
        newWaveCooldownText.text = "";
        newWaveIsCommingText.text = ""; 

        //start spawn enemy
        StartCoroutine(SpawnWave());
    }

    void Update()
    {
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
    
    private void UpdateScore()
    {
        UpdateScoreText();
        if (score < currentLevel.GetDownPoint() || score > currentLevel.GetUpPoint())
        {
            //clear all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject e in enemies)
            {
                Destroy(e);
                //TODO: display animation in the center of the screen
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
            Save();
            //display welcome message
            StartCoroutine(DisplayWelcomeMessage());
        }
        nextLevel = LevelUtil.GetLevel(currentLevel.GetIndex() + 1);
        UpdateCurrentLevelText();
        UpdateNextLevelText();
    }

    private IEnumerator DisplayWelcomeMessage()
    {
        welcomeMessageText.text = currentLevel.GetWelcomeMessage();
        yield return new WaitForSeconds(2);
        welcomeMessageText.text = "";
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
