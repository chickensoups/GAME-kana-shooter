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
    private int enemyEachWaveCount;
    private float waveWait;
    private float spawnWait;

    public Level()
    {
        
    }

    public Level(int index, string name, List<string> questions, List<string> answers, int downPoint, int upPoint, int enemyEachWaveCount, float waveWait, float spawnWait)
    {
        this.index = index;
        this.name = name;
        this.questions = questions;
        this.answers = answers;
        this.downPoint = downPoint;
        this.upPoint = upPoint;
        this.enemyEachWaveCount = enemyEachWaveCount;
        this.waveWait = waveWait;
        this.spawnWait = spawnWait;
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
}
