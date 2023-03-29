using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public UpgradeSystem upgradeSystem;
    public GameObject[] swordPrefab;
    Vector2 boxArea;
    public int _index;
    Animator anim;
    public float sayac;
    public float clýckTime = 1;

    private PlayerController controller;

    private void Start()
    {
        SwordUpdate();

        anim = GetComponent<Animator>();
        transform.rotation = Quaternion.identity;
        boxArea = new Vector2(swordPrefab[_index].GetComponent<SpriteRenderer>().bounds.size.x, swordPrefab[_index].GetComponent<SpriteRenderer>().bounds.size.y);
    }
    public override bool Cooldown()
    {
        DebugDrawBox(swordPrefab[_index].transform.position, boxArea, rotationZ, Color.red);
        return true;
    }
    public void Cut(PlayerController playerController)
    {
        if (controller == null)
            controller = playerController;
        Collider2D[] enemies = Physics2D.OverlapBoxAll(swordPrefab[_index].transform.position, boxArea, rotationZ);

        if (enemies.Length > 0)
        {
            foreach (Collider2D enemy in enemies)
            {
                IDamageable damageable = enemy.GetComponent<IDamageable>();
                damageable?.TakeDamage(1 + StatSystem.instance.GetStatValue(StatType.GunStrong));
            }
        }
        if (_index == 1)
        {
            clýckTime += Time.deltaTime;
            Debug.Log(clýckTime);
            if (clýckTime >= sayac)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    anim.SetBool("Click", true);
                    clýckTime = 0;
                    sayac = 1;
                }
            }
            else if (clýckTime < sayac)
            {
                anim.SetBool("Click", false);
            }
            sayac -= Time.deltaTime;
        }
    }
    public void AreaDamage()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(swordPrefab[_index].transform.position, boxArea.x / 2);

        if (cols.Length > 0)
        {
            foreach (Collider2D enemy in cols)
            {
                IDamageable damageable = enemy.GetComponent<IDamageable>();
                damageable?.TakeDamage(1 + StatSystem.instance.GetStatValue(StatType.GunStrong));
            }
        }
    }

    public void SwordUpdate() //Next sword
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        _index = (int)StatSystem.instance.GetStatValue(StatType.SwordLevel);
        transform.GetChild(_index).gameObject.SetActive(true);

        transform.rotation = Quaternion.identity;
        boxArea = new Vector2(swordPrefab[_index].GetComponent<SpriteRenderer>().bounds.size.x, swordPrefab[_index].GetComponent<SpriteRenderer>().bounds.size.y);
    }

    void DebugDrawBox(Vector2 point, Vector2 size, float angle, Color color)
    {

        var orientation = Quaternion.Euler(0, 0, angle);

        // Basis vectors, half the size in each direction from the center.
        Vector2 right = orientation * Vector2.right * size.x / 2f;
        Vector2 up = orientation * Vector2.up * size.y / 2f;

        // Four box corners.
        var topLeft = point + up - right;
        var topRight = point + up + right;
        var bottomRight = point - up + right;
        var bottomLeft = point - up - right;

        // Now we've reduced the problem to drawing lines.
        Debug.DrawLine(topLeft, topRight, color);
        Debug.DrawLine(topRight, bottomRight, color);
        Debug.DrawLine(bottomRight, bottomLeft, color);
        Debug.DrawLine(bottomLeft, topLeft, color);
    }
}
