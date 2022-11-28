using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Text time;
    [SerializeField] private Text diamond;
    [SerializeField] private Text score;
    [SerializeField] private AudioSource endSE;

    void Start()
    {
        endSE.Play();
        int[] data = Data.GetGameData();

        time.text = "TIME: " + (int) (data[0] / 60) + ":" + data[0] % 60;
        diamond.text = "DIAMOND: " + data[1] + "/" + data[2];
        score.text = "SCORE: " + data[3]; 
    }

}
