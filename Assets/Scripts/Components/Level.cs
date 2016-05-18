using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    private int index;
    private string name;
    private List<string> questions;
    private List<string> answers;
    private int downPoint;
    private int upPoint;
    private int hintPoint;
    private int enemyEachWaveCount;
    private float waveWait;
    private float spawnWait;
    private bool isRotate;
    private bool isFaster;

    public Level()
    {

    }

    public Level(int index, string name, List<string> questions, List<string> answers, int downPoint, int upPoint, int hintPoint,
        int enemyEachWaveCount, float waveWait, float spawnWait, bool isRotate, bool isFaster)
    {
        this.index = index;
        this.name = name;
        this.questions = questions;
        this.answers = answers;
        this.downPoint = downPoint;
        this.upPoint = upPoint;
        this.hintPoint = hintPoint;
        this.enemyEachWaveCount = enemyEachWaveCount;
        this.waveWait = waveWait;
        this.spawnWait = spawnWait;
        this.isRotate = isRotate;
        this.isFaster = isFaster;
    }

    public int GetIndex()
    {
        return index;
    }

    public List<string> GetQuestions()
    {
        return questions;
    }

    public List<string> GetAnswers()
    {
        return answers;
    }

    public float GetWaveWait()
    {
        return waveWait;
    }

    public float GetSpawnWait()
    {
        return spawnWait;
    }

    public int GetEnemyEachWaveCount()
    {
        return enemyEachWaveCount;
    }

    public int GetDownPoint()
    {
        return downPoint;
    }

    public int GetUpPoint()
    {
        return upPoint;
    }

    public int GetHintPoint()
    {
        return hintPoint;
    }

    public bool IsRotate()
    {
        return isRotate;
    }

    public bool IsFaster()
    {
        return isFaster;
    }

    public string GetName()
    {
        return name;
    }
}
