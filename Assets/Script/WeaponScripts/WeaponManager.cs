using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    PlayerController playerController;

    [SerializeField] List<Weapon> weapons = new List<Weapon>();

    public int currentWeaponIndex = 0;

    Weapon currentWeapon = null;


    private void Awake()
    {
        playerController = GetComponent<PlayerController>();

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].gameObject.SetActive(false);
        }

        currentWeapon = weapons[currentWeaponIndex];
        currentWeapon.gameObject.SetActive(true);
    }

    private void Update()
    {
        currentWeapon.WeaponController();

        if (currentWeapon.Cooldown())
        {
            if(currentWeapon is Gun gun)
            {
                gun.Shoot(playerController);
            }
            else if(currentWeapon is Sword sword)
            {
                sword.Cut(playerController);
            }
        }
    }

    public Sword GetSword()
    {
        if (currentWeapon is Sword sword)
            return sword;
        else
            return null;
    }

    public List<UpgradeData> GetCurrentWeaponUpgrades()
    {
        return currentWeapon.weaponUpgrades;
    }

    public void WeaponChange()
    {
        currentWeaponIndex++;
        currentWeapon = weapons[currentWeaponIndex];

        weapons[currentWeaponIndex - 1].gameObject.SetActive(false);
        weapons[currentWeaponIndex].gameObject.SetActive(true);

    }
}
