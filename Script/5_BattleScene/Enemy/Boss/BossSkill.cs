using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class BossSkill : MonoBehaviour
{
    bool crash = false;      // 몸 충돌 데미지 적용 여부
    bool attacking = false;  // 공격중인지 여부
    bool angry = true;     // 분노 여부 (피 40% 이하)
    float attackDelayTime = 0;    // 공격대기 시간
    int currentSkill = -1;
    WaitForSeconds tenDelay = new WaitForSeconds(10.0f);
    WaitForSeconds oneHalfDelay = new WaitForSeconds(1.5f);
    WaitForSeconds oneDelay = new WaitForSeconds(1.0f);
    WaitForSeconds halfDelay = new WaitForSeconds(0.5f);
    Vector3 flipX = new Vector3(1, 1, 1);
    GameObject skillObject;

    BossEnemy bossEnemy;

    // Skill1
    public GameObject skill1Object1;
    public GameObject skill1Object2;
    private LineAtoB line;

    // Skill2
    public GameObject skill2Object;
    public ParticleSystem skill2Particle;

    // Skill3
    public ParticleSystem skill3Particle;

    // Skill4
    public GameObject skill4Object;

    // Special
    public GameObject specialObject1;
    public GameObject specialObject2;
    public ParticleSystem specialParticle;
    public int specialCount = 0;
    public bool specialHit = false;


    private void Awake()
    {
        bossEnemy = GetComponent<BossEnemy>();
        line = skill1Object1.GetComponent<LineAtoB>();
    }

    private void Update()
    {
        if (bossEnemy.status.health <= 0)
        {
            StopAllCoroutines();
            return;
        }
        

        if (attackDelayTime > 0)
        {
            attackDelayTime -= Time.deltaTime;
        }
        else
        {
            attackDelayTime = 0;

            if (!attacking)
            {
                attacking = true;
                if (bossEnemy.status.health < bossEnemy.maxHealth / 4 && angry)
                {
                    StartCoroutine(SpecialSkill());
                    angry = false;
                }
                else
                {
                    while (true)
                    {
                        int a = Random.Range(1, 5);
                        if (a != currentSkill)
                        {
                            currentSkill = a;
                            UseSkill(currentSkill);
                            break;
                        }
                    }
                }
            }
        }
    }

    void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        flipX.x = Mathf.Abs(rotZ) > 90f ? 1 : -1;
        transform.localScale = flipX;
    }

    void AttackReayOn()
    {
        attacking = false;
        attackDelayTime = 5.0f;
    }

    // 스킬을 랜덤으로 받아서 실행시키게 함
    // 스킬을 4개 늘린다면 전에 사용한 스킬을 예외로 하게 할 예정
    private void UseSkill(int select)
    {
        Rotate(bossEnemy.Direction());
        switch (select)
        {
            case 1:
                StartCoroutine(Skill1());
                break;
            case 2:
                StartCoroutine(Skill2());
                break;
            case 3:
                StartCoroutine(Skill3());
                break;
            case 4:
                StartCoroutine(Skill4());
                break;
        }
    }

    // 적을 향해서 돌진 공격
    public IEnumerator Skill1()
    {
        // 플레이어를 향해 일직선 광선 발사
        // LineRenderer를 사용하여 광선 연결

        line.StartPos(transform.position, bossEnemy.target);

        yield return oneHalfDelay;

        // 딜레이 이후 광선 목표 지점을 정지
        // 광선의 위치를 정지

        line.ChangeEnabled();
        Rotate(bossEnemy.Direction());
        bossEnemy.movement.TargetLock();

        yield return halfDelay;
        bossEnemy.movement.MoveChange();
        bossEnemy.movement.Rush();

        bossEnemy.attack1Event?.Invoke();
        crash = true;
        

        AttackReayOn();
    }

    public void UseSkill1()
    {
        bossEnemy.movement.MoveChange();
        crash = false;

        // 폭발 오브젝트 생성
        skillObject = Managers.Pool.Pop(skill1Object2, transform.parent).gameObject;
        skillObject.GetComponent<Explosion>().speed = 25;
        skillObject.GetComponent<Explosion>().power = bossEnemy.status.attack;
        skillObject.transform.position = transform.position;
    }

    // 적(플레이어) 방향으로 검기 5~7개
    public IEnumerator Skill2()
    {
        skill2Particle.Play();

        yield return oneDelay;

        bossEnemy.attack2Event?.Invoke();
        // 공격 애니메이션
        yield return oneHalfDelay;

        AttackReayOn();
    }

    public void UseSkill2()
    {
        Rotate(bossEnemy.Direction());
        skillObject = Managers.Pool.Pop(skill2Object, transform.parent).gameObject;
        skillObject.transform.position = transform.position;
        skillObject.GetComponent<ProjectileController>().direction = (bossEnemy.target.transform.position - transform.position).normalized;
        skillObject.GetComponent<ProjectileController>().targetTag = Tags.Player;
        skillObject.GetComponent<ProjectileController>().Rotate();
    }


    // 플레이어를 향해 짧게 3번 돌진
    public IEnumerator Skill3()
    {
        skill3Particle.Play();

        yield return oneDelay;

        // AddForce 3번
        for (int i = 0; i < 3; i++)
        {
            Rotate(bossEnemy.Direction());
            crash = true;
            bossEnemy.attack3Event?.Invoke();
            bossEnemy.movement.MoveChange();
            bossEnemy.movement.AddForce(bossEnemy.target.position - transform.position, 30.0f);

            // 공격 애니메이션

            yield return oneDelay;

            bossEnemy.movement.MoveChange();
            crash = false;

            yield return oneHalfDelay;
        }

        AttackReayOn();
    }

    public IEnumerator Skill4()
    {
        // 플레이어 정면으로 일반 3타 공격
        bossEnemy.attack4Event?.Invoke();

        yield return oneHalfDelay;

        AttackReayOn();
    }

    public void UseSkill4_1()
    {
        skill4Object.SetActive(true);
        //skill4Object.transform.Translate((bossEnemy.target.transform.position - transform.position).normalized);
        skill4Object.GetComponent<MeleeAttack>().power = bossEnemy.status.attack;
    }

    public void UseSkill4_2()
    {
        skill4Object.SetActive(false);
    }

    // 특수 스킬
    private IEnumerator SpecialSkill()
    {
        // 기믹 수행
        bossEnemy.special1Event?.Invoke();
        StartCoroutine(WhileAttack());

        yield return tenDelay;

        Rotate(bossEnemy.Direction());

        SpecialParticleOff();

        // 기믹 성공 시
        // 보스 스턴
        if (specialCount > 10)
        {
            bossEnemy.stunEvent?.Invoke();
        }
        else
        {
            // 기믹 실패 시
            // 큰 데미지
            yield return oneDelay;
            bossEnemy.special2Event?.Invoke();
            SpecialProjectile();
        }

        specialCount = 0;
        specialHit = false;
        yield return oneHalfDelay;

        AttackReayOn();
    }

    public void SpecialProjectile()
    {
        Rotate(bossEnemy.Direction());
        skillObject = Managers.Pool.Pop(specialObject2, transform.parent).gameObject;
        skillObject.transform.position = transform.position;
        skillObject.GetComponent<ProjectileController>().direction = (bossEnemy.target.transform.position - transform.position).normalized;
        skillObject.GetComponent<ProjectileController>().Rotate();
    }

    private IEnumerator WhileAttack()
    {
        Vector2 randomPosition;
        Vector3 newPosition;
        GameObject clone;
        while (true)
        {
            randomPosition = Random.insideUnitCircle * 7;
            newPosition = new Vector3(randomPosition.x, randomPosition.y, 0) + transform.position;
            clone = Managers.Pool.Pop(specialObject1, transform.parent).gameObject;
            clone.GetComponent<Explosion>().power = bossEnemy.status.attack;
            clone.transform.position = newPosition;

            yield return oneHalfDelay;
        }
    }

    public void SpecialParticleOn()
    {
        specialCount = 10;
        specialHit = true;
        specialParticle.Play();
    }

    public void SpecialParticleOff()
    {
        specialParticle.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!crash) return;

            if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.ApplyDamage(bossEnemy.status.attack);
            }
        }
    }
}
