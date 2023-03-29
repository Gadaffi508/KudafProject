using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 offset;
    public Transform player;
    private float _camSize;
    private Camera cam;
    public float MaxSize;
    public float MinSize;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        _camSize = cam.orthographicSize;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position+offset,moveSpeed*Time.deltaTime);
        Zoom();
    }

    void Zoom()
    {
        if (Mathf.Abs(cam.orthographicSize - _camSize)>0.05)
        {
            float change = Mathf.Lerp(cam.orthographicSize, _camSize, Time.deltaTime * 2);
            cam.orthographicSize = change;
        }
        if (Input.mouseScrollDelta.y > 0 && _camSize>MinSize)
        {
            _camSize -= 1;
        }
        else if (Input.mouseScrollDelta.y < 0 && _camSize < MaxSize)
        {
            _camSize += 1;
        }
    }
}
