using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D player;
    
    //Stats
    [SerializeField] private Image[] lives;
    private int livesRemaining = 3;

    //Audio
    [SerializeField] private AudioSource hitSE;
    [SerializeField] private AudioSource collectSE;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(StringStore.trap))
        {
            LoseLive();
            if (livesRemaining == 0) {
                Death();
            }
            else 
            {
                Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag(StringStore.heart))
        {
            collectSE.Play();
            Destroy(collider.gameObject);
            GainLive();
            //Debug.Log("Lives Remaining = " + livesRemaining);
        }
    }


    private void LoseLive() 
    {
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        //Debug.Log("Lives Remaining = " + livesRemaining);
    }

    private void GainLive() 
    {
        if (livesRemaining < 3) {
            lives[livesRemaining].enabled = true;
            livesRemaining++;
            //Debug.Log("Get Heart, Lives Remaining = " + livesRemaining);
        }
    }


    private void Hit() {
        hitSE.Play();
        animator.SetTrigger(StringStore.hit);
        player.bodyType = RigidbodyType2D.Static;
        //Debug.Log("After Hit, Lives Remaining = " + livesRemaining);
    }

    private void Death()
    {
        animator.SetTrigger(StringStore.die);
        player.bodyType = RigidbodyType2D.Static;
    }  

    public void Respawning() 
    {
        animator.SetTrigger(StringStore.respawn);
        transform.position = Checkpoint.respawnPoint;
        player.bodyType = RigidbodyType2D.Dynamic;

        FallingPlatform.Restart();
    }  

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
