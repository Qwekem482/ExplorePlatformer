using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    //Unity Elements
    private Animator animator;
    private Rigidbody2D player;
    
    //Stats
    [SerializeField] private Image[] lives;
    private int livesRemaining = 3;

    private Vector3 respawnPoint;
    [SerializeField] private GameObject endOfWorld;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();

        respawnPoint = transform.position;
    }

    private void Update()
    {
        WorldEndPosition();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            LoseLive();
            if (ZeroLive()) {
                Death();
            }
            else 
            {
                Hit();
                //Respawning();
            }
        }
    }

    private void LoseLive() 
    {
        livesRemaining--;
        lives[livesRemaining].enabled = false;
    }

    private void Hit() {
        animator.SetTrigger(StringStore.hit);
        player.bodyType = RigidbodyType2D.Static;
    }

    private bool ZeroLive()
    {
        if (livesRemaining == 0) 
        {
            return true;
        }
        return false;
    }

    private void Death()
    {
        animator.SetTrigger(StringStore.die);
        player.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GainLive() 
    {
        livesRemaining++;
        lives[livesRemaining].enabled = true;
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
        animator.SetTrigger(StringStore.respawn);
        transform.position = respawnPoint;
        player.bodyType = RigidbodyType2D.Dynamic;
    }

    private void CheckPoint() 
    {
        respawnPoint = transform.position;
    }


    
}
