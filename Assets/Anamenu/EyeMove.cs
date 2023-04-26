using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMove : MonoBehaviour
{
    public Camera cam;
    Vector3 worldPosition;
    Vector2 _result;
    void Awake()
    {
        _result=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        worldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        transform.position = worldPosition;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
        _result.x-0.5f,_result.x+0.7f),
        Mathf.Clamp(transform.position.y,
        1.3f, 2.45f));
    }
}
