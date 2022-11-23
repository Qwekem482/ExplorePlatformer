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
        }
    }

    private void CheckPoint() 
    {
        respawnPoint = transform.position;
    }
}
