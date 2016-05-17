using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelUtil
{
    public static string[] ENG_CHARS = { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko", "sa", "shi", "su", "se", "so", "ta", "chi", "tsu", "te", "to" };
    public static string[] HIRA_CHARS = { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ", "さ", "し", "す", "せ", "そ", "た", "ち", "つ", "て", "と" };
    public static string[] KATA_CHARS = { "ア", "イ", "ウ", "エ", "オ", "カ", "キ", "ク", "ケ", "コ", "サ", "シ", "ス", "セ", "ソ", "タ", "チ", "ツ", "テ", "ト" };

    private static List<Level> levels; //hold all levels data
    private static List<int> checkPoints; //hold all checkpoint
        
    public static void Init()
    {
        //level 1
        List<string> answer = new List<string>(new[] { "a", "i", "u", "e", "o" });
        List<string> questions = new List<string>(new[] { "あ", "い", "う", "え", "お" });
        Level level1 = new Level(0, "Level 1", questions, answer, 0, 100, 10, 4 , 2, false, false);

        //level 2
        answer = new List<string>(new[] { "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "か", "き", "く", "け", "こ" });
        Level level2 = new Level(1, "Level 2", questions, answer, 100, 200, 10, 4, 1, true, false);

        //level 3
        answer = new List<string>(new[] { "a", "i", "u", "e", "o", "ka", "ki", "ku", "ke", "ko" });
        questions = new List<string>(new[] { "あ", "い", "う", "え", "お", "か", "き", "く", "け", "こ" });
        Level level3 = new Level(2, "Level 3", questions, answer, 200, 500, 10, 4, 1, false, false);

        //level 4
        answer = new List<string>(new[] { "sa", "shi", "su", "se", "so" });
        questions = new List<string>(new[] { "さ", "し", "す", "せ", "そ" });
        Level level4 = new Level(3, "Level 4", questions, answer, 500, 600, 10, 4, 1, false, false);

        //push all level to levels
        levels = new List<Level>(new Level[] { level1, level2, level3, level4 });
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
