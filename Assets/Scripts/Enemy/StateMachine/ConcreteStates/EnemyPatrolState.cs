using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    private Transform _targetPoint;
    private Vector3 _direction;
    public EnemyPatrolState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if(enemy.IsAggroed)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        _targetPoint = enemy.patrolPoints[enemy.currentPoint];

        _direction = (_targetPoint.position - enemy.transform.position).normalized;

        enemy.MoveEnemy(_direction);

        if(Vector2.Distance(enemy.transform.position, _targetPoint.position) < 0.2f)
        {
            enemy.currentPoint = (enemy.currentPoint + 1) % enemy.patrolPoints.Length;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationTriggerEvent()
    {
        base.AnimationTriggerEvent();
    }
}
