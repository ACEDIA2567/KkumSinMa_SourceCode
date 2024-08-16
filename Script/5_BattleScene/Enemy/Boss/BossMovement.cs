using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private BossEnemy enemy;
    public Rigidbody2D rigid;
    
    private float tolerance = 1f; // 거리 임계값
    private Vector3 direction;
    private Vector3 targetPos;
    private float speed = 0;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<BossEnemy>();
    }

    private void FixedUpdate()
    {
        if (speed > 0)
        {
            direction = targetPos - transform.position;
            if (direction.magnitude > tolerance)
            {
                rigid.velocity = direction.normalized * speed;
            }
            else
            {

                rigid.velocity = Vector3.zero;
                speed = 0;
            }
        }
    }

    public void MoveChange()
    {
        if (rigid.constraints == RigidbodyConstraints2D.FreezeRotation)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void Rush()
    {
        speed = 30.0f;
    }

    public void TargetLock()
    {
        targetPos = enemy.target.position;
    }

    public void AddForce(Vector3 target, float speed)
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(target.normalized * speed, ForceMode2D.Impulse);
    }
}
