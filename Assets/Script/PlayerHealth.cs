using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Destroy(gameObject, 1.5f);
        GetComponent<PlayerController>().enabled = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy" || other.gameObject.tag == "Gun")
        {
            anim.SetTrigger("heart");
            
        }
    }
    public void canAttırma()
    {
        health += StatSystem.instance.GetStatValue(StatType.PlayerHealth);
    }
}
