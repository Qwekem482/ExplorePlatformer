using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    private static int totalCollectDiamond = 0;
    private static int totalDiamond = 0;
    private static int totalTime = 0;
    private static int totalScore = 0;

    private static int level = 0;
    private static int collectDiamond = 0;
    private static int allDiamond = 0;
    private static int time = 0;
    private static int score = 0;

    public static void AddData()
    {
        level = SceneManager.GetActiveScene().buildIndex - 2;
        allDiamond = Scoring.GetTotalDiamond();
        collectDiamond = Scoring.GetDiamond();
        time = (int) Time.timeSinceLevelLoad;
        score = CalcScore();

        totalCollectDiamond += collectDiamond;
        totalDiamond += allDiamond;
        totalTime += time;
        totalScore += score;

        Scoring.ResetDiamond(); 
    }

    public static int[] GetLevelData()
    {
        int[] data = new int[5];
        data[0] = level;
        data[1] = time;
        data[2] = collectDiamond;
        data[3] = allDiamond;
        data[4] = score;
        return data;
    }

    public static int[] GetGameData()
    {
        int[] data = new int[4];
        data[0] = totalTime;
        data[1] = totalCollectDiamond;
        data[2] = totalDiamond;
        data[3] = totalScore;
        return data;
    }

    public static int GetLevel()
    {
        return level;
    }

    private static int CalcScore()
    {
        return 100 + collectDiamond * 10 + (int) Time.timeSinceLevelLoad / 100;
    }


}
