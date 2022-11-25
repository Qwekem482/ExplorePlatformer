using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 respawnPoint;

    void Start()
    {
        respawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(StringStore.checkpoint))
        {
            CheckPoint();
            collision.gameObject.GetComponent<Animator>().SetInteger(StringStore.activeStage, 1);
        }
    }

    private void CheckPoint() 
    {
        respawnPoint = transform.position;
    }
}
