using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCollector : MonoBehaviour
{
    private int diamondCount = 0;

    [SerializeField] private Text diamondNumber;

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag(StringStore.diamond)) 
        {
            DiamondController.animator.SetBool(StringStore.collected, true);
            Destroy(collider.gameObject);
            diamondCount++;
            //Debug.Log("Diamonds: " + Count.diamondCount);
            diamondNumber.text = "Diamonds: " + diamondCount;
        }
    }
}
