using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    [field: SerializeField] public int XPPoints { get; private set;}
    public Rigidbody2D RB { get; set; }

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public EnemyPatrolState PatrolState { get; set; }
    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    public Rigidbody2D BulletPrefab;
    public Transform[] patrolPoints;
    public int currentPoint = 0;

    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 1f;

    void Awake()
    {
        StateMachine = new();
        IdleState = new(this, StateMachine);
        ChaseState = new(this, StateMachine);
        AttackState = new(this, StateMachine);
        PatrolState = new(this, StateMachine);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        CurrentHealth = MaxHealth;
        XPPoints = 20 + Random.Range(0, 32);

        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(PatrolState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= (float)Math.Floor(damageAmount);

        if(CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        LevelUpManager.instance.AddXP(XPPoints);
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        RB.linearVelocity = velocity;
    }

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }
}
