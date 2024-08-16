using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : NormalEnemy
{
    [SerializeField]
    private GameObject attackRange;

    private void AttackRangeActive()
    {
        attackRange.SetActive(false);
    }

    private void AttackStart()
    {
        clips.PlaySFX(EnemyClip.Attack);
        attackRange.SetActive(true);
        attackRange.GetComponent<MeleeAttack>().power = status.attack;
    }
}
