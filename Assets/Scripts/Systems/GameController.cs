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
    public static bool hint;
    public Text scoreText;

    public Text currentLevelText;
    public Text nextLevelText;

    private float newWaveCooldown;
    private float newWaveCooldownRate;
    private float nextNewWaveUpdateTime;

    public Text newWaveText;
    private Image newWaveImage;
    private ProgressBar.ProgressRadialBehaviour newWaveProgress;

    public Text welcomeMessageText;
    public Text levelChangeMessage;

    public static int currentEnemyId;

    public static Level currentLevel;
    private Level nextLevel;

    public Sprite pauseBtnImg;
    public Sprite resumeBtnImg;

    public AudioSource[] audios;

    private AudioSource bgAudio;
    private AudioSource levelUpAudio;
    private AudioSource levelDownAudio;

    public GameObject scoreAnimationText;
    public GameObject enemyExplosion;

    private Button pauseBtn;
    public static bool pause;

    GameObject[] tutorialGameObjects;

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

    public static string GetQuestion(int index)
    {
        return currentLevel.GetQuestions()[index];
    }

    public static string GetAnswer(int index)
    {
        return currentLevel.GetAnswers()[index];
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

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        return null;
    }

    private void WeaponChanged(GameObject weapon)
    {
        MinusScore(Constants.CHANGE_WEAPON_MINUS_SCORE);
        GameObject scoreTextAnimation = (GameObject)Instantiate(scoreAnimationText, weapon.transform.position, Quaternion.identity);
        scoreTextAnimation.GetComponentInChildren<TextMesh>().text = "-" + Constants.CHANGE_WEAPON_MINUS_SCORE;
    }

    void PauseButtonClick()
    {
        if (pause)
        {
            pauseBtn.GetComponentInParent<Image>().sprite = pauseBtnImg;
            Time.timeScale = 1;
            bgAudio.volume = 1.0f;
        }
        else
        {
            pauseBtn.GetComponentInParent<Image>().sprite = resumeBtnImg;
            Time.timeScale = 0;
            bgAudio.volume = 0.0f;
        }
        pause = !pause;
    }

    private void UpdateNewWaveCooldown()
    {
        if (newWaveCooldown < 0)
        {
            newWaveCooldown = 0;
            newWaveText.text = "";
            newWaveImage.enabled = false;
            newWaveProgress.Value = 0;
        }
        else
        {
            newWaveProgress.IncrementValue(100 / (currentLevel.GetWaveWait() / newWaveCooldownRate));
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
            //set new wave cooldown
            newWaveCooldown = currentLevel.GetWaveWait();
            newWaveText.text = "New wave is comming!!!";
            newWaveImage.enabled = true;
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

    private void DisplayTutorial()
    {
        if (score > -Constants.TUTORIAL_POINT && score < Constants.TUTORIAL_POINT)
        {
            for (int i = 0; i < tutorialGameObjects.Length; i++)
            {
                tutorialGameObjects[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < tutorialGameObjects.Length; i++)
            {
                tutorialGameObjects[i].SetActive(false);
            }
        }
    }

    private void UpdateScore()
    {
        DisplayTutorial();
        UpdateScoreText();
        hint = score < currentLevel.GetHintPoint();
        if (score < currentLevel.GetDownPoint() || score > currentLevel.GetUpPoint())
        {
            //clear all enemies
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject e in enemies)
            {
                Instantiate(enemyExplosion, e.transform.position, e.transform.rotation);
                Destroy(e);
            }

            if (score < currentLevel.GetDownPoint())
            {
                currentLevel = LevelUtil.DownLevel(currentLevel);
                //animation when level down
                StartCoroutine(MainLightController.LightDown());
                StartCoroutine(DisplayLevelUpDownMessage("So sad, Round down!"));
                //audio when level down
                levelDownAudio.Play();
            }
            else if (score > currentLevel.GetUpPoint())
            {
                currentLevel = LevelUtil.UpLevel(currentLevel);
                //animation when level up
                StartCoroutine(MainLightController.LightUp());
                StartCoroutine(DisplayLevelUpDownMessage("Great, Round up!"));
                //audio when level up
                levelUpAudio.Play();
                if (currentLevel.GetIndex() == Constants.TOTAL_ROUND)
                {
                    //display congratulation message when player become Kana master
                }
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

    private IEnumerator DisplayLevelUpDownMessage(string message)
    {
        levelChangeMessage.text = message;
        yield return new WaitForSeconds(2);
        levelChangeMessage.text = "";
    }

    private void UpdateCurrentLevelText()
    {
        currentLevelText.text = currentLevel.GetName();
    }

    private void UpdateNextLevelText()
    {
        nextLevelText.text = "Next Round: " + (nextLevel.GetDownPoint() - score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void Awake()
    {
        WeaponChoosen.WeaponChanged += WeaponChanged;
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

        ////load level and score depend on saved data
        //currentLevel = LevelUtil.GetLevel(1);
        //nextLevel = LevelUtil.GetLevel(2);
        //score = 0;
        tutorialGameObjects = GameObject.FindGameObjectsWithTag("tutorial");

        //display welcome message
        StartCoroutine(DisplayWelcomeMessage());
        //Update Score first time
        UpdateScore();

        //new wave
        newWaveCooldown = 0;
        newWaveCooldownRate = 0.1f;
        nextNewWaveUpdateTime = Time.time;
        newWaveText = GameObject.Find("New wave text").GetComponent<Text>();
        newWaveText.text = "";
        newWaveImage = GameObject.Find("New wave image").GetComponent<Image>();
        newWaveImage.enabled = true;
        newWaveProgress = newWaveImage.GetComponent<ProgressBar.ProgressRadialBehaviour>();
        newWaveProgress.Value = 0;

        //init pause/resume button
        pauseBtn = GameObject.FindGameObjectWithTag("PauseBtn").GetComponent<Button>();
        pauseBtn.onClick.AddListener(PauseButtonClick);
        pause = false;

        //init audio sources
        audios = GetComponents<AudioSource>();
        bgAudio = audios[0];
        levelUpAudio = audios[1];
        levelDownAudio = audios[2];

        //start spawn enemy
        StartCoroutine(SpawnWave());

        GoogleAdsController.RequestBanner();
    }

    void Update()
    {
        if (newWaveCooldown > 0)
        {
            newWaveCooldown -= Time.deltaTime;
            if (Time.time > nextNewWaveUpdateTime)
            {
                UpdateNewWaveCooldown();
            }
        }
    }

    public void OnApplicationQuit()
    {
        Save();
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        pause = pauseStatus;
    }

    public void OnApplication()
    {
        pause = false;
    }

    public void OnApplicationFocus(bool focusStatus)
    {
        if (!focusStatus)
        {
            Save();
        }
    }

}
