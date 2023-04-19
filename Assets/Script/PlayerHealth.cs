using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Image[] healt;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        healt[2].enabled = true;
        healt[1].enabled = false;
        healt[0].enabled = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        
        if(health<=70 && health>50)
        {
            healt[2].enabled = false;
            healt[1].enabled = true;
            healt[0].enabled = false;

        }else if(health<=50)
        {
            healt[2].enabled = false;
            healt[1].enabled = false;
            healt[0].enabled = true;
        }
        else if(health==0 && health<0)
        {
            healt[2].enabled = false;
            healt[1].enabled = false;
            healt[0].enabled = false;
        }
    }

    void Die()
    {
        anim.SetTrigger("died");
        GetComponent<PlayerController>().enabled = false;
        StartCoroutine(Timezero());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Gun")
        {
            anim.SetTrigger("heart");
            
        }
    }
    public void canAttýrma()
    {
        health += StatSystem.instance.GetStatValue(StatType.PlayerHealth);
    }
    IEnumerator Timezero()
    {
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
    }
}
