using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;



public class EndLevel : MonoBehaviour
{
    [SerializeField] private Text level;
    [SerializeField] private Text time;
    [SerializeField] private Text diamond;
    [SerializeField] private Text score;

    [SerializeField] private AudioSource endLvSE;

    //private enum fields {level, collectDiamond, allDiamond, time, score}

    void Start()
    {
        endLvSE.Play();
        
        float[] data = Data.GetLevelData();

        level.text = "YOU HAVE COMPLETED LEVEL " + data[0]; //[(int) fields.level];
        time.text = "TIME: " + (int) (data[1] / 60) + ":" + Math.Round(data[1] % 60, 2);
        diamond.text = "DIAMOND: " + data[2] + "/" + data[3];
        score.text = "SCORE: " + data[4]; 
    }
}
