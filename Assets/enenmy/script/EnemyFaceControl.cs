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
            transform.localScale = new Vector3(1f,1f,0);
        }
        else
        {
            transform.localScale = new Vector3(-1f, 1f,0);
        }
    }
}
