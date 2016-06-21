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
        // HRAGANA ZONE
        //level 0
        int index = 0;
        string name = "Round " + index + "/" + Constants.TOTAL_ROUND;
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

        //level 1
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        welcomeMessage = "Welcome to Hiragana Zone!";
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
        welcomeMessage = "Ops, nice bro! try this one!";
        answer = new List<string>(new[] { "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "か", "き", "く", "け", "こ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level3 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 4
        welcomeMessage = "Rolling in the deep!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 1000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level4 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 5
        welcomeMessage = "Time to learn something new =.=";
        answer = new List<string>(new[] { "sa", "shi", "su", "se", "so" });
        questions = new List<string>(new[] { "さ", "し", "す", "せ", "そ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 1200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 1400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 1700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level7 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 8
        welcomeMessage = "You did the right thing. Move on!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 2000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level8 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 9
        welcomeMessage = "Did you forget them from beginning!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 2500;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level9 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 10
        welcomeMessage = "I like rotate and buff speed so much :D";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 3000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level10 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 11
        welcomeMessage = "Na` na` na na' na na' na (The Beatles - Hey Jude)";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no" });
        questions = new List<string>(new[] { "な", "に", "ぬ", "ね", "の" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 3200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 3400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 3700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level13 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 14
        welcomeMessage = "Rolling in the deeperrrr!!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 4000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level14 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 15
        welcomeMessage = "Finding MeMo @@";
        answer = new List<string>(new[] { "ma", "mi", "mu", "me", "mo" });
        questions = new List<string>(new[] { "ま", "み", "む", "め", "も" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 4200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 4400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level16 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 17
        welcomeMessage = "Mix them in, pls!";
        answer = new List<string>(new[] { "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 4700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level17 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 18
        welcomeMessage = "Mixing, rolling, running T_T";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 5000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level18 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 19
        welcomeMessage = "Sorry, nothing to write here!";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 5500;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level19 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 20
        welcomeMessage = "YTTOR, GNIHTON OT ETIRW EREH";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 6000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level20 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 21
        welcomeMessage = "Only 3 enemy types, are you happy!";
        answer = new List<string>(new[] { "ya", "yu", "yo" });
        questions = new List<string>(new[] { "や", "ゆ", "よ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 6200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 6400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
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
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 6700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level23 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 24
        welcomeMessage = "Try your best! You almost reach awesome point!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 7000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level24 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 25
        welcomeMessage = "You shall not pass!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 8500;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 15;
        waveWait = 3;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level25 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 26, hiragana final
        welcomeMessage = "Last round of Hiragana Zone!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 10000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 4;
        waveWait = 3;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level26 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        // KATAKANA ZONE
        //level 27
        answer = new List<string>(new[] { "a", "i", "u", "e", "o" });
        questions = new List<string>(new[] { "ア", "イ", "ウ", "エ", "オ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        welcomeMessage = "Welcome to KATAKANA Zone!";
        downPoint = upPoint;
        upPoint = 10200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;

        Level level27 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 28
        welcomeMessage = "Ops, nice bro! try this one!";
        answer = new List<string>(new[] { "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "カ", "キ", "ク", "ケ", "コ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 10400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level28 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 29
        welcomeMessage = "Let practice!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 10700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level29 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 30
        welcomeMessage = "Rolling in the deep!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 11000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level30 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 31
        welcomeMessage = "Time to learn something new =.=";
        answer = new List<string>(new[] { "sa", "shi", "su", "se", "so" });
        questions = new List<string>(new[] { "サ", "シ", "ス", "セ", "ソ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 11200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level31 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 32
        welcomeMessage = "You are doing well, next 5 enemy types!";
        answer = new List<string>(new[] { "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "タ", "チ", "ツ", "テ", "ト" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 11400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level32 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 33
        welcomeMessage = "Practice time! 'Barrier': 'Dont let's them touch me!'";
        answer = new List<string>(new[] { "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 11700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level33 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 34
        welcomeMessage = "You did the right thing. Move on!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 12000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 4;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level34 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 35
        welcomeMessage = "Did you forget them from beginning!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to" });
        questions = new List<string>(new[] { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 12500;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level35 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 36
        welcomeMessage = "I like rotate and buff speed so much :D";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 13000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level36 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 37
        welcomeMessage = "Na` na` na na' na na' na (The Beatles - Hey Jude)";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no" });
        questions = new List<string>(new[] { "ナ", "ニ", "ヌ", "ネ", "ノ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 13200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level37 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 38
        welcomeMessage = "haha hihi 'fufu' hehe hoho! wadafa, fu = hu?";
        answer = new List<string>(new[] { "ha", "hi", "fu", "he", "ho" });
        questions = new List<string>(new[] { "ハ", "ヒ", "フ", "ヘ", "ホ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 13400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level38 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 39
        welcomeMessage = "I am sparta!!!!!!!!!!";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho" });
        questions = new List<string>(new[] { "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 13700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level39 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 40
        welcomeMessage = "Rolling in the deeperrrr!!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 14000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level40 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 41
        welcomeMessage = "Finding MeMo @@";
        answer = new List<string>(new[] { "ma", "mi", "mu", "me", "mo" });
        questions = new List<string>(new[] { "マ", "ミ", "ム", "メ", "モ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 14200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level41 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 42
        welcomeMessage = "Nice kiss, right? https://youtu.be/atiLxS-rf6g";
        answer = new List<string>(new[] { "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "ラ", "リ", "ル", "レ", "ロ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 14400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level42 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 43
        welcomeMessage = "Mix them in, pls!";
        answer = new List<string>(new[] { "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 14700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level43 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 44
        welcomeMessage = "Mixing, rolling, running T_T";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 15000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level44 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 45
        welcomeMessage = "Sorry, nothing to write here!";
        answer = new List<string>(new[] { "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro" });
        questions = new List<string>(new[] { "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 15500;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level45 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 46
        welcomeMessage = "YTTOR, GNIHTON OT ETIRW EREH";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 16000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 12;
        waveWait = 3;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level46 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 47
        welcomeMessage = "Only 3 enemy types, are you happy!";
        answer = new List<string>(new[] { "ya", "yu", "yo" });
        questions = new List<string>(new[] { "ヤ", "ユ", "ヨ" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 16200;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level47 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 48
        welcomeMessage = "Special enemy types!";
        answer = new List<string>(new[] { "wa", "wo", "n" });
        questions = new List<string>(new[] { "ワ", "ヲ", "ン" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 16400;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 5;
        waveWait = 5;
        spawnWait = 4;
        isRotate = false;
        isFaster = false;
        Level level48 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 49
        welcomeMessage = "You had learned so far!";
        answer = new List<string>(new[] { "ya", "yu", "yo", "wa", "wo", "n" });
        questions = new List<string>(new[] { "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 16700;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level49 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 50
        welcomeMessage = "Try your best! You almost reach awesome point!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 17000;
        hintPoint = downPoint + 50;
        enemyEachWaveCount = 10;
        waveWait = 4;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level50 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 51
        welcomeMessage = "You shall not pass!";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n" });
        questions = new List<string>(new[] { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ", "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 18500;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 15;
        waveWait = 3;
        spawnWait = 4;
        isRotate = false;
        isFaster = true;
        Level level51 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 52, katakana final
        welcomeMessage = "Try to beat last round of KATAKANA!";
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 20000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 15;
        waveWait = 3;
        spawnWait = 4;
        isRotate = true;
        isFaster = true;
        Level level52 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 53
        welcomeMessage = "Hiragana + Katakana!! How possible?";
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n", "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to", "na", "ni", "nu", "ne", "no", "ha", "hi", "fu", "he", "ho", "ma", "mi", "mu", "me", "mo", "ra", "ri", "ru", "re", "ro", "ya", "yu", "yo", "wa", "wo", "n" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん", "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ", "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 22000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 15;
        waveWait = 4;
        spawnWait = 3;
        isRotate = true;
        isFaster = true;
        Level level53 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 54
        welcomeMessage = "HIRAGA vs KATAKANA";
        answer = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん" });
        questions = new List<string>(new[] {"ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ", "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 25000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 20;
        waveWait = 3;
        spawnWait = 3;
        isRotate = true;
        isFaster = true;
        Level level54 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);

        //level 55
        welcomeMessage = "Can't believe you reach this level!!! Ohayo Kana master!";
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と", "な", "に", "ぬ", "ね", "の", "は", "ひ", "ふ", "へ", "ほ", "ま", "み", "む", "め", "も", "ら", "り", "る", "れ", "ろ", "や", "ゆ", "よ", "わ", "を", "ん" });
        answer = new List<string>(new[] { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト", "ナ", "ニ", "ヌ", "ネ", "ノ", "ハ", "ヒ", "フ", "ヘ", "ホ", "マ", "ミ", "ム", "メ", "モ", "ラ", "リ", "ル", "レ", "ロ", "ヤ", "ユ", "ヨ", "ワ", "ヲ", "ン" });
        index += 1;
        name = "Round " + index + "/" + Constants.TOTAL_ROUND;
        downPoint = upPoint;
        upPoint = 1000000;
        hintPoint = downPoint + 100;
        enemyEachWaveCount = 20;
        waveWait = 3;
        spawnWait = 3;
        isRotate = true;
        isFaster = true;
        Level level55 = new Level(index, name, welcomeMessage, questions, answer, downPoint, upPoint, hintPoint, enemyEachWaveCount, waveWait, spawnWait, isRotate, isFaster);
        
        //push all level to levels
        levels =
            new List<Level>(new Level[]
            {
                level0, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10, level11,
                level12, level13,
                level14, level15, level16, level17, level18, level19, level20, level21, level22, level23, level24,
                level25, level26, level27, level28, level29, level30, level31, level32, level33, level34, level35,
                level36, level37, level38, level39, level40, level41, level42, level43, level44, level45, level46, level47, level48, level49, level50, level51, level52, level53, level54, level55 });
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
