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

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            LoseLive();
            ZeroLive();
            if (ZeroLive()) {
                //Death();
            }
            else 
            {
                Hit();
                //Respawn();
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




    
}
