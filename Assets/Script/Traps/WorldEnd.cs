using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnd : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Update is called once per frame
    private void Update()
    {
        Position();
    }

    private void Position() 
    {
        transform.position = new Vector2(player.transform.position.x, transform.position.y);
    }
}
