using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Fighter"))
        {
            animator.SetBool("check", true);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        animator.SetBool("check", false);
    }
}
