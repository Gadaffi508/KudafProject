using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject puf = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(puf, 0.5f);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("mermi"))
        {
            GameObject puf = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(puf, 0.5f);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Gun"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth charecter))
        {
            charecter.TakeDamage(10);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            GameObject puf = Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(puf, 0.5f);
            Destroy(gameObject);
        }
    }
}
