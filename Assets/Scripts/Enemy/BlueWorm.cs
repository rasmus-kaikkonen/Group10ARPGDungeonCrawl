using UnityEngine;

public class BlueWorm : Enemy
{
    private Transform[] patrolPoints;
    public Transform waypointParent;
    /*public Transform player;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float detectRange = 5f;
    private bool isWaiting;
    float distanceToPlayer;
    private Animator _animator;
    


    private int currentPoint = 0;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _LastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    

    private void Awake()
    {
        
        _animator = GetComponent<Animator>();
    }
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
            
            Chase();

        else if (distanceToPlayer > 25)
        {
            Idle();
        }
        else

            Patrol();


    }

    void Patrol()
    {
        
        Transform target = patrolPoints[currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, patrolSpeed * Time.deltaTime);
        
        _animator.SetFloat(_horizontal, transform.position.x);
        _animator.SetFloat(_vertical, transform.position.y);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        
        
    }

    void Chase()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        
        _animator.SetFloat(_horizontal, transform.position.x);
        _animator.SetFloat(_vertical, transform.position.y);

    }
    void Idle()
    {
        _animator.SetFloat(_LastHorizontal, transform.position.x);
        _animator.SetFloat(_lastVertical, transform.position.y);
    }*/
}

