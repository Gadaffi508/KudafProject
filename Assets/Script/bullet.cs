
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float out_speed=10;
    public GameObject hiteffect;

    public BoxCollider2D bulletCollider;

    public float hiz, guc;

    public float NumOfBounces = 3;
    private Vector3 lastVelocity;
    private Vector3 direction;
    private float curSpeed;
    private int curBounces;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,3f);
    }
    private void shoot()
    {
        rb.AddForce(transform.right * (Gun(StatType.BulletSpeed) + out_speed),ForceMode2D.Impulse); // kullanmamýþsýn fonksiyonu þunu kullanýrýz
    }

    public void init()
    {
        this.guc = Gun(StatType.GunStrong);
        this.NumOfBounces = Gun(StatType.Bouncess);
        if (NumOfBounces>0)
        {
            Boxcolider();
        }

        shoot();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent<enemy_yarasa>(out enemy_yarasa yarasa))
        {
            yarasa.TakeDamage(5+ Gun(StatType.GunStrong));

        }
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);

        if (collision.gameObject.TryGetComponent<EnemyTower>(out EnemyTower tower))
        {
            tower.TakeDamage(5 + Gun(StatType.GunStrong));

        }
        GameObject effect2 = Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(effect2, 0.5f);
        Destroy(gameObject);


    }
    private void LateUpdate()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (curBounces >= NumOfBounces) return;
        curSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(curSpeed,0);
        curBounces++;
        if (collision.gameObject.TryGetComponent<EnemyTower>(out EnemyTower tower))
        {
            tower.TakeDamage(5 + Gun(StatType.GunStrong));

        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            GameObject effect3 = Instantiate(hiteffect, transform.position, Quaternion.identity);
            Destroy(effect3, 0.5f);
            Destroy(gameObject);
        }

    }
    public void Boxcolider()
    {
        bulletCollider.isTrigger = false;
    }
    public float Gun(StatType type)
    {
        return StatSystem.instance.GetStatValue(type);
    }


}
