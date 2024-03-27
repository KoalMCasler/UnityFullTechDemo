using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    
    public enum EnemyState{ Patrolling, Chasing, Searching, Attacking, Retreating}
    [Header("State")]
    public EnemyState enemyState;
    [Header("State Colors")]
    public Color PatrolColor;
    public Color ChaseColor;
    public Color SearchColor;
    public Color AttackColor;
    public Color RetreatColor;
    [Header("Object References")]
    public Material enemyHead;
    public GameObject player;
    public TextMeshProUGUI activeStateHUD;
    [Header("Pathfinding")]
    public NavMeshAgent agent;
    [SerializeField]
    private WaypointPath waypointPath;
    private int targetWaypointIndex;
    private Transform previousWaypoint;
    private Transform targetWaypoint;
    public int targetDistance;
    [Header("Targeting")]
    public int damage;
    public float detectRange;
    public float escapeRange;
    public int searchTime;
    public float searchTimer;
    public float distanceFromPlayer;
    public int attackRange;
    public int attackTime;
    public float attackTimer;
    void Start()
    {
        attackTimer = attackTime;
        searchTimer = searchTime;
        enemyState = EnemyState.Patrolling;
        player = GameObject.FindWithTag("Player");
        TargetNextWaypoint();
    }
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position,transform.position);
        switch(enemyState)
        {
            case EnemyState.Patrolling: Patrolling(); break;
            case EnemyState.Chasing: Chasing(); break;
            case EnemyState.Searching: Searching(); break;
            case EnemyState.Attacking: Attacking(); break;
            case EnemyState.Retreating: Retreating(); break;
        }
    }
    void Patrolling()
    {
        enemyHead.SetColor("_Color", PatrolColor);
        RunPatrol();
        activeStateHUD.text = "Patrolling";
    }
    void Chasing()
    {
        enemyHead.SetColor("_Color", ChaseColor);
        ChasePlayer();
        activeStateHUD.text = "Chasing";
    }
    void Searching()
    {
        enemyHead.SetColor("_Color", SearchColor);
        SearchForPlayer();
        activeStateHUD.text = "Searching";
    }
    void Attacking()
    {
        enemyHead.SetColor("_Color", AttackColor);
        AttackPlayerInRange();
        activeStateHUD.text = "Attacking";
    }
    void Retreating()
    {
        enemyHead.SetColor("_Color", RetreatColor);   
        StartRetreat();
        activeStateHUD.text = "Retreating";
    }

    void RunPatrol()
    {
        agent.SetDestination(targetWaypoint.position);
        if (Vector3.Distance(this.transform.position, targetWaypoint.position) < targetDistance)
        {
            TargetNextWaypoint();
        }
        if(distanceFromPlayer <= detectRange)
        {
            enemyState = EnemyState.Chasing;
        }
    }
    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
    }
    void ChasePlayer()
    {
        targetWaypoint = player.transform;
        agent.SetDestination(targetWaypoint.position);
        if(distanceFromPlayer > escapeRange)
        {
            Transform LastSeenLocation = player.transform;
            targetWaypoint = LastSeenLocation;
            searchTimer = searchTime;
            enemyState = EnemyState.Searching;
        }
        if(distanceFromPlayer <= attackRange)
        {
            attackTimer = attackTime;
            enemyState = EnemyState.Attacking;
        }

    }
    void SearchForPlayer()
    {
        searchTimer -= Time.deltaTime;
        if(searchTimer <= 0 && distanceFromPlayer > detectRange)
        {
            searchTimer = searchTime;
            enemyState = EnemyState.Retreating;
        }
        if(distanceFromPlayer <= detectRange)
        {
            enemyState = EnemyState.Chasing;
        }
    }
    void StartRetreat()
    {
        targetWaypoint = previousWaypoint;
        agent.SetDestination(targetWaypoint.position);
        if(Vector3.Distance(this.transform.position, targetWaypoint.position) < targetDistance)
        {
            enemyState = EnemyState.Patrolling;
        }
        if(distanceFromPlayer <= detectRange)
        {
            enemyState = EnemyState.Chasing;
        }
    }
    void AttackPlayerInRange()
    {
        attackTimer -= Time.deltaTime;
        if(distanceFromPlayer <= attackRange && attackTimer < 0)
        {
            player.GetComponent<PlayerController>().TakeDamage(damage);
            attackTimer = attackTime;
        }
        if(distanceFromPlayer > attackRange)
        {
            enemyState = EnemyState.Chasing;
        }
    }
}
