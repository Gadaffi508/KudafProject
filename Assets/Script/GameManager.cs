using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ScoreGUI;
    PlayerController player;
    PlayerHealth playerH;
    public Text time;
    public int killenemy=0;
    public Text kilenemy;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        ScoreGUI.SetActive(false);
    }
    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    private void FixedUpdate()
    {
        time.text ="Time : " + player.time.ToString();
        kilenemy.text = "Kill Enemy : " + killenemy.ToString();

        OpenGUI();
    }
    void OpenGUI()
    {
        if (playerH.health<=0)
        {
            ScoreGUI.SetActive(true);
        }
    }
}
