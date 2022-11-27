using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D boxCollider;
    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Unhide player when appear in new level
        collider.gameObject.SetActive(true);

        if(collider.gameObject.CompareTag(StringStore.player))
        {
            if (gameObject.CompareTag(StringStore.nextLevel))
            {
                //Hide player at the end of a level
                collider.gameObject.SetActive(false);
            }   
        } 

        animator.SetTrigger(StringStore.doorTrigger);

        //Prevent open door continously when player at the start of new level
        gameObject.GetComponent<BoxCollider2D>().enabled = false;      
    }

    private void TryNextLevel()
    {
        if (gameObject.CompareTag(StringStore.nextLevel))
        {
   ;
            Data.AddData();
            //All end door lead to NextLevelScene
            SceneManager.LoadScene(1);
            Checkpoint.respawnPoint = transform.position;
        }

    }
}
