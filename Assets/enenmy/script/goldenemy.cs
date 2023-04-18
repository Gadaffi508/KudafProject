using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goldenemy : MonoBehaviour
{
    public float expValue;
    private Transform player;
    public float followSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void goldFollow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime); 
    }
    private void Update()
    {
        StartCoroutine(folowtime());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            XPmanager.xInstance.SetExperience(expValue);
            Destroy(gameObject);
        }
    }
    IEnumerator folowtime()
    {
        yield return new WaitForSeconds(1);
        goldFollow();
    }
}
