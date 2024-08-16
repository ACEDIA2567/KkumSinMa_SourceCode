using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Wait,
    Chase,
    Turn,
    Attack,
    Wander
}

public abstract class Enemy : MonoBehaviour
{
    public EnemyStatus status;
    public GameObject soul;

    public Transform target;
    public int maxHealth;

    protected virtual void Awake()
    {
        maxHealth = status.health;
    }

    private void OnEnable()
    {
        status.health = maxHealth;
    }

    public virtual void Init(Transform playerTransform)
    {
        // 싱글톤 또는 Find로 플레이어 위치 검색
        target = playerTransform;
    }

    private void EnemyDie()
    {
        for (int i = 0; i < status.soul; i++)
        {
            GameObject souls = Managers.Pool.Pop(soul, transform.parent.parent).gameObject;
            souls.GetComponent<Soul>().GetTarget(target);
            souls.transform.position = transform.position;
        }

        if (transform.root.TryGetComponent<NormalMapManager>(out NormalMapManager normalMapManager))
        {
            normalMapManager.SubtractCount();
        }

        Managers.Pool.Push(transform.parent.gameObject);

    }
}
