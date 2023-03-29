using System.Collections;
using UnityEngine;

public class enemy_yarasa : MonoBehaviour, IDamageable
{
    public GameObject effect;
    public float health = 100;
    public GameObject _goldd;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Gun"))
        {
            Debug.Log("Dokunur");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponentInParent<PlayerHealth>();
            player.TakeDamage(5);

            GameObject puf = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(puf, 0.5f);
            Destroy(transform.parent.gameObject);
            Debug.Log("Dokunur1");
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
    
    


}
