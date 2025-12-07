using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;

public class Map : MonoBehaviour
{
    [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    

    [SerializeField] Direction direction;
    [SerializeField] Transform teleportTargetPosition;
    [SerializeField] float addpos = 2;
    enum Direction {Up,Down,Left,Right,Teleport}

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            /*confiner.BoundingShape2D = mapBoundry;
            UpdatePlayerPosition(collision.gameObject);
            */
           
            FadeTransition(collision.gameObject);
        }
    }

    async void FadeTransition(GameObject player)
    {
        PauseMenu.PauseGame2();
        await ScreenFader.instance.FadeOut();

        confiner.BoundingShape2D = mapBoundry;
        UpdatePlayerPosition(player);
        

        await ScreenFader.instance.FadeIn();
        


    }

    private void UpdatePlayerPosition(GameObject player)
    {
        if(direction == Direction.Teleport)
        {
            player.transform.position = teleportTargetPosition.position;
            return;
        }
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
