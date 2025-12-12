using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody2D RB { get; set; }

    void MoveEnemy(Vector2 velocity);
}
