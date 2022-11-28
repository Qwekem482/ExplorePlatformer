using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private static int diamondCount = 0;
    private static int totalDiamond = 0;

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
            //Debug.Log("Diamonds: " + diamondCount);
            Destroy(collider.gameObject);
            //Debug.Log("Time: " + Time.timeSinceLevelLoad);
        }
    }

    public static int GetDiamond()
    {
        return diamondCount;
    }

    public static int GetTotalDiamond()
    {
        return totalDiamond;
    }

    public static void ResetDiamond()
    {
        diamondCount = 0;
    }
}
