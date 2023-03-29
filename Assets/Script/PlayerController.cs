using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public GameObject dirRoot;
    public GameObject PlayerSprite;
    Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        directionAttach();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed() * Time.fixedDeltaTime);
    }
    void directionAttach()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);

        Vector2 pos = transform.position;
        Vector2 offset = new Vector2(mousepos.x-pos.x,mousepos.y-pos.y);

        dirRoot.transform.up = offset.normalized;

        float axe = dirRoot.transform.rotation.eulerAngles.z;

        bool right = axe > 180;

        float currentDir = PlayerSprite.transform.localScale.x;

        if (right && currentDir != 1)
        {
            turn(1);
        }
        if (!right && currentDir != 1)
        {
            turn(-1);
        }
    }
    void turn(int dir)
    {
        Vector2 scale = new Vector2(dir,1);
        PlayerSprite.transform.localScale = scale;
    }

    public float Speed()
    {
        return StatSystem.instance.GetStatValue(StatType.MoveSpeed);
    }

}
