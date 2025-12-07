using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public Transform waypointParent;
    public Transform player;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectRange = 5f;
    private bool isWaiting;
    public float distanceToPlayer;

    private int currentPoint = 0;
   // private enum State { Patrol, Chase }
   // private State currentState = State.Patrol;

    private void Start()
    {
            patrolPoints = new Transform[waypointParent.childCount];

            for (int i = 0; i < waypointParent.childCount; i++)
            {
                patrolPoints[i] = waypointParent.GetChild(i);
            }

        
    }

    void Update()
    {
        if (PauseMenu.IsPaused || isWaiting)
        {
            return;
        }

        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer < detectRange)
            //currentState = State.Chase;
            Chase();
        else
            //currentState = State.Patrol;
            Patrol();


        /*switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;

            case State.Chase:
                Chase();
                break;
        }*/
    }

    void Patrol()
    {
        Transform target = patrolPoints[currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }

    void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }
}

