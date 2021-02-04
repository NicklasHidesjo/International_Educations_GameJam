using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("Zombie Range")]
    [Tooltip("Range for detecting the player")]
    [SerializeField] float detectionRange = 3f;
    [Tooltip("Range for how far away the player can be before giving up the chase")]
    [SerializeField] float followRange = 5f;
    [Tooltip("Range where the object starts attacking the player")]
    [SerializeField] float attackRange = 1f;


    [Header("Speed")]
    [Tooltip("The speed that the object will patrol at")]
    [SerializeField] float patrolSpeed = 10f;
    [Tooltip("The speed that the object will chase the player at")]
    [SerializeField] float followSpeed = 20f;

    [Header("Patrol")]
    [Tooltip("Place the patrol points in here in the order you wish the object to walk")]
    [SerializeField] Transform[] path = new Transform[0];
    [Tooltip("This is the time in seconds that the object will wait before moving on to the new point")]
    [SerializeField] float waitTime = 1f;



    [SerializeField] bool isFollowing = false;
    [SerializeField] bool waiting = false;
    [SerializeField] int pathIndex = 0;

    Transform player = null;
    NavMeshAgent navMeshAgent;
    GamePlayManager gamePlayManager;
    SoundScript soundScript;

    void Start()
    {
        GetComponents();
        Init();
    }

    private void GetComponents()
    {
        player = FindObjectOfType<SimpleKeyboard>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        gamePlayManager = FindObjectOfType<GamePlayManager>();
        soundScript = FindObjectOfType<SoundScript>();
    }

    private void Init()
    {
        navMeshAgent.speed = patrolSpeed;
        pathIndex = Random.Range(0, path.Length);
        navMeshAgent.SetDestination(path[pathIndex].position);
        transform.position = path[pathIndex].position;
    }


    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        if (!gamePlayManager.AllowedToMove) return;
        HandleWalking();
    }

    private void HandleWalking()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        CheckifShouldFollow(distance);

        if(isFollowing)
        {
            FollowPlayer(distance);
        }
        else
        {
            WalkAlongPath();
        }
    }

    private void CheckifShouldFollow(float distance)
    {
        if (!isFollowing && distance < detectionRange)
        {
            soundScript.ZombieDetectingSound(0.1f);
            isFollowing = true;
            navMeshAgent.speed = followSpeed;
        }
        else if (isFollowing && distance > followRange)
        {
            isFollowing = false;
            navMeshAgent.speed = patrolSpeed;
            navMeshAgent.destination = transform.position;
            StartCoroutine(PatrolWaiting());
        }
    }

    private void FollowPlayer(float distance)
    {
        if(isFollowing)
        navMeshAgent.SetDestination(player.position);
        if (distance < attackRange)
            AttackPlayer();
    }

    private void AttackPlayer()
    {
        soundScript.source.Stop();
        soundScript.AttackingSounds(0.5f);
        player.GetComponent<PlayerDeath>().Death();
    }

    private void WalkAlongPath()
    {
        float x = path[pathIndex].position.x;
        float z = path[pathIndex].position.z;



        if (!waiting && transform.position.x == x && transform.position.z == z)
        {
            waiting = true;
            StartCoroutine(PatrolWaiting());
        }

    }

    IEnumerator PatrolWaiting()
    {
        Debug.Log("Getting new pos");
        yield return new WaitForSeconds(waitTime);
        pathIndex = Random.Range(0, path.Length);
        navMeshAgent.destination = path[pathIndex].position;
        waiting = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }
}
