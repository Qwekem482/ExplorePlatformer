using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    [SerializeField] private GameObject endOfWorld;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        WorldEndPosition();
    }

    private void WorldEndPosition() 
    {
        endOfWorld.transform.position = new Vector2(transform.position.x, endOfWorld.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Checkpoint"))
        {
            CheckPoint();
        }
    }

    public void Respawning() 
    {
        transform.position = respawnPoint;
    }

    private void CheckPoint() 
    {
        transform.position = respawnPoint;
    }
}
