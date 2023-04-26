using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatEnemy : MonoBehaviour, IDamageable
{
    private Animator animator;
    AIPath aIPath;
    public float health = 100;
    public GameObject _goldd;
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
        PlayerHealth player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
        player.TakeDamage(5);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Die();
            _goldd = Instantiate(_goldd, transform.position, Quaternion.identity);
        }
    }
}
