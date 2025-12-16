using UnityEngine;

public interface IMoveable
{
    Rigidbody2D RB { get; set; }

    void MovePlayer(Vector2 velocity) {}
}
