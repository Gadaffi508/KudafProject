using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BananaBullet : MonoBehaviour
{
    public float Radius;
    public float  Force, explodeForce;
    public Transform target;
    private Rigidbody2D rb;
    private Vector2 stopMove;
    private float random;
    public LayerMask layerMask;
    bool bom;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,Radius);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(BananaEnemy.direction * Force);
        random = Random.Range(0.5f,1.2f);
        Invoke("BulletStop",random);

    }

   
    void FixedUpdate()
    {
            Collider2D[] hit›nfo = Physics2D.OverlapCircleAll(transform.position, Radius, layerMask);

            foreach (Collider2D ray in hit›nfo)
            {
                Vector2 Direction = ray.transform.position - transform.position;
                if (bom)
                {
                    ray.GetComponent<Rigidbody2D>().AddForce(Direction * explodeForce);
                    Debug.Log("igerideeddeded");
                    PlayerHealth player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
                    player.TakeDamage(15);
                    Destroy(this.gameObject,0.01f);
                }
             
            }
        
     
    }
    private void BulletStop()
    {
        stopMove = transform.position;
        transform.position = stopMove;
        rb.velocity = Vector2.zero;
        bom = true;

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerHealth>();
            player.TakeDamage(10);
        }
    }
   
}
