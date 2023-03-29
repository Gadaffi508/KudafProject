using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    float fireRate = 0.25f;
    float timer = 0;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;



    private void Start()
    {
        timer = fireRate;
    }

    public override bool Cooldown()
    {
        if(timer > fireRate)
        {
            return true;
        }
        else
            timer += Time.deltaTime;
        return false;
    }

    public void Shoot(PlayerController playerController)
    {
        if (Input.GetMouseButton(0))
        {
            bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation).GetComponent<bullet>();
            bullet.init();
            timer = 0;
        }
    }
}
