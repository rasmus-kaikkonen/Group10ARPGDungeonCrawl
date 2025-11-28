using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class Map : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;

    [SerializeField] Direction direction;
    [SerializeField] float addpos = 2;
    enum Direction {Up,Down,Left,Right}

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPosition(collision.gameObject);
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;

        switch (direction)
        {
            case Direction.Up:
                newPos.y += addpos;
                break;
            case Direction.Down:
                newPos.y -= addpos;
                break;
            case Direction.Left:
                newPos.x += addpos;
                break;
            case Direction.Right:
                newPos.x -= addpos;
                break;
        }

        player.transform.position = newPos;
    }    

}
