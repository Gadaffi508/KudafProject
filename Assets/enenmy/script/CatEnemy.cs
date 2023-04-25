using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemy : MonoBehaviour
{
    private Animator animator;
    AIPath aIPath;
    void Start()
    {
        animator = GetComponent<Animator>();
        aIPath = GetComponentInParent<AIPath>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("touched",true);
            aIPath.maxSpeed = 0.0f;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("touched", false);
            aIPath.maxSpeed = 3.0f;
        }
    }

    public void AttackDamage()
    {
        //Hasar Kodlarý
    }
}
