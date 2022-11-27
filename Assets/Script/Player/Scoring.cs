using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private int diamondCount = 0;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag(StringStore.diamond)) 
        {
            diamondCount++;
            Debug.Log("Diamonds: " + diamondCount);
            Destroy(collider.gameObject);
            Debug.Log("Time: " + Time.timeSinceLevelLoad);
            Debug.Log("Score: " + CalcScore());
        }
    }

    private int CalcScore()
    {
        return 100 + diamondCount * 10 + (int) Time.timeSinceLevelLoad / 100;
    }
}
