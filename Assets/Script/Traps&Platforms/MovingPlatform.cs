using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float speed;

    private int wpIndex = 0;

    private void Update()
    {
        if (Vector2.Distance(waypoints[wpIndex].transform.position, transform.position) < .1f) {
            ChangeIndex();
        }

        MovePlatform();
    }

    private bool CheckRangeIndex() 
    {
        return wpIndex >= waypoints.Length;
    }

    private void ChangeIndex() 
    {
        wpIndex++;

        if (CheckRangeIndex())
        {
            wpIndex = 0;
        }
    }

    private void MovePlatform() 
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[wpIndex].transform.position, Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
