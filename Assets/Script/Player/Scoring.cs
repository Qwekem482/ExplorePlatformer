using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private static int diamondCount;
    private static int totalDiamond;

    [SerializeField] private AudioSource collectSE;

    void Start()
    {
        totalDiamond = GameObject.FindGameObjectsWithTag(StringStore.diamond).Length;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag(StringStore.diamond)) 
        {
            collectSE.Play();
            diamondCount++;
            Debug.Log("Diamonds: " + diamondCount);
            Destroy(collider.gameObject);
            Debug.Log("Time: " + Time.timeSinceLevelLoad);
        }
    }

    private int CalcScore()
    {
        return 100 + diamondCount * 10 + (int) Time.timeSinceLevelLoad / 100;
    }

    public static int GetDiamond()
    {
        return diamondCount;
    }

    public static int GetTotalDiamond()
    {
        return totalDiamond;
    }
}
