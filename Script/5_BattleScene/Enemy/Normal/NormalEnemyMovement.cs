using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class NormalEnemyMovement : MonoBehaviour
{
    private NormalEnemy enemy;
    [SerializeField] private NavMeshAgent agent;

    private Vector3 flipX = new Vector3(1, 1, 1);
    private float tolerance = 0.1f; // 거리 임계값
    public Vector3 turnPos; // 시작 지점

    // 플레이어 추격 관련
    public bool attacking = false;
    public float trackingTime = 0.0f;

    private EnemyState currentState;

    private void Awake()
    {
        enemy = GetComponent<NormalEnemy>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        enemy.attackEvent += StopMove;
        enemy.hitEvent += StopMove;
        enemy.dieEvent += StopMove;
    }

    private void Start()
    {
        agent.enabled = true;
        agent.speed = enemy.status.moveSpeed;
    }

    private void OnEnable()
    {
        agent.speed = enemy.status.moveSpeed;
        currentState = EnemyState.Idle;
    }

    public void StateChange(EnemyState state)
    {
        currentState = state;
    }

    public EnemyState GetState()
    {
        return currentState;
    }

    private void State()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                break;

            case EnemyState.Wait:
                WaitDistance();
                break;

            case EnemyState.Chase:
                Movement(enemy.target.position);
                break;

            case EnemyState.Turn:
                Movement(turnPos);
                break;

            case EnemyState.Attack:
                break;
        }
    }

    private void FixedUpdate()
    {
        if (!agent.isOnNavMesh) return;

        if (enemy.status.health <= 0)
        {
            agent.speed = 0;
            return;
        }
        

        if (trackingTime > 0)
        {
            if (!attacking)
            {
                trackingTime -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if (currentState == EnemyState.Chase)
            {
                enemy.moveEvent?.Invoke();
                currentState = EnemyState.Turn;
            }
        }

        State();
    }

    private void StopMove()
    {
        agent.isStopped = true;
    }

    private void StartMove()
    {
        agent.isStopped = false;
        enemy.moveEvent?.Invoke();
        currentState = EnemyState.Chase;
    }

    private void WaitDistance()
    {
        if ((enemy.target.position - transform.position).magnitude > enemy.status.attackRange)
        {
            enemy.moveEvent?.Invoke();
            StartMove();
            currentState = EnemyState.Chase;
        }
        else if (!attacking)
        {
            attacking = true;
            enemy.attackEvent?.Invoke();
            currentState = EnemyState.Attack;
        }
    }

    private void Movement(Vector3 goalPos)
    {
        agent.SetDestination(goalPos);
        Rotate(goalPos - transform.position);
        if (currentState == EnemyState.Turn)
        {
            if ((goalPos - transform.position).magnitude < tolerance)
            {
                enemy.idleEvent?.Invoke();
                currentState = EnemyState.Idle;
            }
        }
        else if (currentState == EnemyState.Chase) 
        {
            if ((goalPos - transform.position).magnitude < enemy.status.attackRange)
            {
                if (!attacking)
                {
                    attacking = true;
                    enemy.attackEvent?.Invoke();
                    currentState = EnemyState.Attack;
                }
                else
                {
                    StopMove();
                    enemy.idleEvent?.Invoke();
                    currentState = EnemyState.Wait;
                }
            }
        }
    }

    protected void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        flipX.x = Mathf.Abs(rotZ) > 90f ? 1 : -1;
        transform.localScale = flipX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (currentState == EnemyState.Idle)
            {
                currentState = EnemyState.Chase;
                enemy.moveEvent?.Invoke();
                trackingTime = 10.0f;
            }
        }
    }
}
