using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaEnemy : MonoBehaviour, IDamageable
{
    public float Radius;
    public Transform target,firePoint;
    public static Vector2 direction;
    private bool Detected;
    public float fireRate,Force;
    private float nextTimeFireRate = 0;
    public GameObject bullet;
    private Animator animator;
    public float health = 100;
    public GameObject _goldd;
    private AIPath path;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
    void Start()
    {
        path = GetComponentInParent<AIPath>();
        Physics2D.queriesStartInColliders = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;

        RaycastHit2D attackArea = Physics2D.Raycast(transform.position, direction,Radius);

        if (attackArea)
        {
            if (attackArea.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
        }
        else
        {
            if (Detected == true)
            {
                Detected = false;
                animator.SetBool("Trigger", false);
            }
        }
        if (Detected)
        {
            animator.SetBool("Trigger",true);
            if (Time.time > nextTimeFireRate)
            {
                nextTimeFireRate = Time.time + 1 / fireRate;
               
            }
            path.maxSpeed = 0.3f;
        }
        else
        {
            path.maxSpeed = 3f;
        }
    }

    public void Shoot()
    {
       Instantiate(bullet, firePoint.position, Quaternion.identity);
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
