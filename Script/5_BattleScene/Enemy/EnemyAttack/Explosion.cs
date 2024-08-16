using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    GameObject min;
    [SerializeField]
    GameObject max;

    public int power;
    public int speed = 5;
    private Vector3 addVector3 = new Vector3(0.1f, 0.1f, 0.1f);

    private IDamagable target;

    private void OnEnable()
    {
        min.transform.localScale = addVector3;
    }

    void FixedUpdate()
    {
        // 작은 폭발 부분이 큰 폭발 부분과 일치하거나 커지면
        if (min.transform.localScale.magnitude >= max.transform.localScale.magnitude)
        {
            if (target != null)
            {
                target.ApplyDamage(power);
            }
            Managers.Pool.Push(gameObject);
        }
        else
        {
            min.transform.localScale += addVector3 * speed * Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable) && collision.gameObject.CompareTag("Player"))
        {
            target = damagable;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable) && collision.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }
}
