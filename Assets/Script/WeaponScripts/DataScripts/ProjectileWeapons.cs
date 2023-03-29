using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/Projectile Weapon")]
public class ProjectileWeapons : WeaponData
{
    public float bulletSpeed = 1;
    public int bulletBounces = 3;
}
