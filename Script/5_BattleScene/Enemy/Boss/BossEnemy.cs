using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy, IDamagable
{
    public Action attack1Event;
    public Action attack2Event;
    public Action attack3Event;
    public Action attack4Event;
    public Action special1Event;
    public Action special2Event;
    public Action dieEvent;
    public Action stunEvent;

    public BossMovement movement;
    BossSkill skill;
    BossAnimator animator;

    private Vector3 direction;

    void Start()
    {
        Init(Managers.Game.player.transform);
    }

    protected override void Awake()
    {
        base.Awake();
        movement = GetComponent<BossMovement>();
        animator = GetComponent<BossAnimator>();
        skill = GetComponent<BossSkill>();
    }

    public Vector2 Direction()
    {
        if (target == null)
            target = Managers.Game.player.transform;
        direction = target.transform.position - transform.position;
        return direction;
    }

    public void ApplyDamage(float dmg)
    {
        if (status.health <= dmg)
        {
            // 죽음
            dieEvent?.Invoke();
            skill.StopAllCoroutines();
            movement.rigid.velocity = Vector3.zero;

            // 스테이지 클리어
            MapGenerator.instance.StageClear();
        }
        else
        {
            if (skill.specialHit)
            {
                skill.specialCount++;
                status.health -= 1;
            }
            else
            {
                status.health -= (int)dmg;
            }
            MapGenerator.instance.Hit(maxHealth, status.health);
        }
    }
}