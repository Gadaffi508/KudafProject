using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkullEnemy : MonoBehaviour
{
    public Transform target;
    public float Radius,Force;
    private Vector2 direction;
    private bool Detected;
    private AIPath aıPath;
    private int jumpNum = 0;
    private Rigidbody2D enemRb;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, Radius);
       
    }
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        enemRb = GetComponent<Rigidbody2D>();
        aıPath = GetComponentInParent<AIPath>();
        Force =0;
        jumpNum = 1;
    }

    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D jumpArea = Physics2D.Raycast(transform.position, direction, Radius);

        if (jumpArea)
        {
            if (jumpArea.collider.gameObject.CompareTag("Player"))
            {
                if (Detected == false)
                {
                    Detected = true;
                    Debug.Log("Ýçeride");
                    
                }
            }
        }
        else
        {
            if (Detected == true)
            {
                Detected = false;
                Debug.Log("Diþarýda");
               

            }
        }

        if (Detected == true)
        {
           
            if (jumpNum == 1)
            {
                jumpNum = 0;
                Force = 10;
                enemRb.AddForce(direction * Force);
            }
            
        }
        else if(Detected == false)
        {
            jumpNum = 1;
            if (jumpNum == 0)
            {
                Force = 0;
            }
          
            
        }

    }
   
}
