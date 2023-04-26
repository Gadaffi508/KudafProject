using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1.0f;
        transform.DOMoveY(540,2);
    }
    public void loadScene()
    {
        SceneManager.LoadScene(1);
    }
}
