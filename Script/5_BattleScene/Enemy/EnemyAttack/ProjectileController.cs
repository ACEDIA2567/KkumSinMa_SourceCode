using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    Rigidbody2D rigid;
    public int power;
    public Vector3 direction;
    private int speed = 7;

    public float flightTime;
    public Tags targetTag;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
//        Invoke("Destroy", (flightTime == 0f?5f:flightTime));
    }

    void Update()
    {
        rigid.velocity = direction * speed;
    }

    public void Rotate()
    {
        transform.right = direction;
    }

    private void Destroy()
    {
        Debug.Log("Destroy Projectile");
        Managers.Pool.Push(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable) && collision.gameObject.CompareTag(targetTag.ToString()))
        {
            if (collision.GetType() == typeof(BoxCollider2D))
            {
                Debug.Log("projectile meet target");
                damagable.ApplyDamage(power);
                Managers.Pool.Push(gameObject);
            }
        }
        else if (collision.CompareTag("Wall"))
        {
            Managers.Pool.Push(gameObject);
        }
    }
}
