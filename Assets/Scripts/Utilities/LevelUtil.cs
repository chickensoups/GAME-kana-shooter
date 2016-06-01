using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelUtil
{
    public static string[] ENG_CHARS = { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n" };
    public static string[] HIRA_CHARS = { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん" };
    public static string[] KATA_CHARS = { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ", "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン" };

    private static List<Level> levels; //hold all levels data

    public static void Init()
    {
        //level 1
        int index = 0;
        string name = "Level " + index;
        string welcomeMessage = "OMG! Negative point! Trying more!";
        List<string> answer = new List<string>(new[] { "a", "i", "u", "e", "o" });
        List<string> questions = new List<string>(new[] { "あ", "い", "う", "え", "お" });
        int downPoint = -1000000;
        int upPoint = 0;
        int hintPoint = 0;
        int enemyEachWaveCount = 4;
        float waveWait = 5;
        float spawnWait = 4;
        bool isRotate = false;
        bool isFaster = false;

        Level level0 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        index += 1;
        name = "Level " + index;
        welcomeMessage = "Welcome to Hiraga Zone!";
        downPoint = 0;
        upPoint = 200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;

        Level level1 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 2
        welcomeMessage = "Ops, you had level up!";
        answer = new List<string>(new[] { "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "か", "き", "く", "け", "こ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level2 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 3
        welcomeMessage = "Let practice!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level3 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 4
        welcomeMessage = "Practice harder with faster and rotate enemy!";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 1000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level4 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 5
        welcomeMessage = "Time to learn something new =.=";
        answer = new List<string>(new[] { "sa", "shi", "su", "se", "so" });
        questions = new List<string>(new[] { "さ", "し", "す", "せ", "そ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 1200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level5 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 6
        welcomeMessage = "You are doing well, next 5 enemy types!";
        answer = new List<string>(new[] { "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "た", "ち", "つ", "て", "と" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 1400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level6 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 7
        welcomeMessage = "Practice time! 'Barrier': 'Dont let's them touch me!'";
        answer = new List<string>(new[] { "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 1700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level7 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 8
        welcomeMessage = "You did the right thing. Move on!";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 2000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level8 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 9
        welcomeMessage = "Did you forget them from beginning!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 2500;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level9 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 10
        welcomeMessage = "I like rotate and buff speed so much :D";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 3000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level10 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 11
        welcomeMessage = "Na` na` na na' na na' na (The Beatles - Hey Jude)";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no" });
        questions = new List<string>(new[] { "な", "に", "ぬ", "ね", "の" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 3200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level11 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 12
        welcomeMessage = "haha hihi 'fufu' hehe hoho! wadafa, fu = hu?";
        answer = new List<string>(new[] { "ha", "hi", "fu", "he", "ho" });
        questions = new List<string>(new[] { "は", "ひ", "ふ", "へ", "ほ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 3400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level12 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 13
        welcomeMessage = "I am sparta!!!!!!!!!!";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho" });
        questions = new List<string>(new[] { "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 3700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level13 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 14
        welcomeMessage = "Rolling in the deeperrrr!!";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 4000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level14 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 15
        welcomeMessage = "Finding MeMo @@";
        answer = new List<string>(new[] { "ma", "mi", "mu", "me", "mo" });
        questions = new List<string>(new[] { "ま", "み", "む", "め", "も" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 4200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level15 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 16
        welcomeMessage = "Nice kiss, right? https://youtu.be/atiLxS-rf6g";
        answer = new List<string>(new[] { "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "ら", "り", "る", "れ", "ろ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 4400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level16 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 17
        welcomeMessage = "Mix them in, pls!";
        answer = new List<string>(new[] { "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 4700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level17 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 18
        welcomeMessage = "Mixing, rolling, running T_T";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 5000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level18 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 19
        welcomeMessage = "Sorry, nothing to write here!";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 5500;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level19 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 20
        welcomeMessage = "YTTOR, GNIHTON OT ETIRW EREH";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 6000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level20 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 21
        welcomeMessage = "Only 3 enemy types, are you happy!";
        answer = new List<string>(new[] { "ya", "yu", "yo" });
        questions = new List<string>(new[] { "や", "ゆ", "よ" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 6200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level21 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 22
        welcomeMessage = "Special enemy types!";
        answer = new List<string>(new[] { "wa", "wo", "n" });
        questions = new List<string>(new[] { "わ", "を", "ん" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 6400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level22 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 23
        welcomeMessage = "You had learned so far!";
        answer = new List<string>(new[] { "ya", "yu", "yo", "wa", "wo", "n" });
        questions = new List<string>(new[] { "や", "ゆ", "よ", "わ", "を", "ん" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 6700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level23 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 24
        welcomeMessage = "Try your best! You almost reach awesome point!";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 7000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level24 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 25
        welcomeMessage = "You shall not pass!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん" });
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 8500;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level25 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 26, hiragana final
        welcomeMessage = "Last round of Hiragana Zone!";
        index += 1;
        name = "Level " + index;
        downPoint = upPoint;
        upPoint = 10000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level26 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //push all level to levels
        levels =
            new List<Level>(new Level[]
            {
                level0, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11, level12, level13,
                level14, level15, level16, level17, level18, level19, level20, level21, level22, level23, level24,
                level25, level26 });
    }


    public static Level DownLevel(Level currentLevel)
    {
        if (currentLevel.GetIndex() <= 0)
        {
            return levels.First();
        }
        return levels[currentLevel.GetIndex() - 1];
    }

    public static Level UpLevel(Level currentLevel)
    {
        if (currentLevel.GetIndex() >= levels.Count - 1)
        {
            return levels.Last();
        }
        return levels[currentLevel.GetIndex() + 1];
    }

    public static Level GetLevel(int index)
    {
        if (index <= 0)
        {
            return levels.First();
        }
        if (index >= levels.Count - 1)
        {
            return levels.Last();
        }
        return levels[index];
    }
}
