using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProj : MonoBehaviour
{
    public GameObject direRoot;
    public GameObject mermi;
    public float bullet_speed;
    public Transform bullet_spawn;
    float fireRate=0.25f;
    float gecensure = 0;

    private void Awake()
    {
        mermi.GetComponent<bullet>().out_speed = bullet_speed;
    }

    void Update()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {

            if (direRoot.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (direRoot.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }

        }
        if(gecensure<2) { gecensure += Time.deltaTime; }

        if (Input.GetKey(KeyCode.Mouse0) && gecensure>fireRate)
        {
            Instantiate(mermi,bullet_spawn.transform.position,bullet_spawn.transform.rotation).GetComponent<bullet>();
            gecensure = 0;
        }
    }
}
