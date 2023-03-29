using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour, IDamageable
{
    public float expValue;
    public GameObject _goldd;
    public float health = 1000;

    public float range,gecensure;
 
    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject Gun;

    public GameObject Bullet;

    public float fireRate;

    float nextTimeFire=0;

    public Transform ShootPoint;

    public float Force;


    private void Shoot()
    {
        if (gecensure>2)
        {
            GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
            gecensure = 0;
        }
      
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
            _goldd = Instantiate(_goldd, transform.position, Quaternion.identity);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        gecensure += Time.deltaTime;
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (Detected == false)
                {
                    Detected = true;
                   
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                   
                }

            }
        }

        if (Detected)
        {
            if (Time.time > nextTimeFire)
            {
                nextTimeFire = Time.time+1/fireRate;
                Shoot();
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
