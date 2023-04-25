using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaceControl : MonoBehaviour
{
    public Transform target;
    public GameObject obje;
  

    void Update()
    {
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(0.4f,0.4f,0);
        }
        else
        {
            transform.localScale = new Vector3(-0.4f, 0.4f,0);
        }
    }
}
