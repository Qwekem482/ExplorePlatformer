using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallTime = 0.5f;
    private float destroyTime = 50f;

    private Rigidbody2D rigid;
    private Animator animator;

    private Vector3 startPosition;
    private static bool restart = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }


    private void Update()
    {
        if (restart)
        {
            rigid.bodyType = RigidbodyType2D.Static;
            transform.position = startPosition;
            animator.SetBool(StringStore.fall, false);
            restart = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(StringStore.player))
        {
            StartCoroutine(Fall());
            StartCoroutine(Hide());
        }
    }

    private IEnumerator Fall() 
    {
        yield return new WaitForSeconds(fallTime);

        rigid.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool(StringStore.fall, true);
    }

    private IEnumerator Hide() 
    {
        yield return new WaitForSeconds(destroyTime);
        gameObject.SetActive(false);
    }

    public static void Restart()
    {
        restart = true;
    }
}
