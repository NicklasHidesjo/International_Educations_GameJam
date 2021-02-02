using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform[] path = new Transform[0];

    [SerializeField] Transform player = null;
    [SerializeField] float detectionRange = 10f;
    [SerializeField] float followRange = 20f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float waitTime = 1f;

    NavMeshAgent navMeshAgent;    

    bool isFollowing = false;

    bool waiting = false;
    bool walkback = false;
    int pathIndex = 0;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        transform.position = path[0].position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (!isFollowing)
        {
            WalkAlongPath();
            isFollowing = false;
        }
        else if (distance < attackRange)
        {
            Debug.Log("attacking player");
        }
        else if(distance < detectionRange)
        {
            navMeshAgent.SetDestination(player.position);
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

    }

    private void WalkAlongPath()
    {
        if (path.Length == 0)
            navMeshAgent.SetDestination(path[0].position);
        else
            navMeshAgent.SetDestination(path[pathIndex].position);

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
        yield return new WaitForSeconds(waitTime);
        if (walkback)
            pathIndex--;
        else
            pathIndex++;

        if (pathIndex > path.Length || pathIndex < 0)
        {
            walkback = !walkback;
        }
        waiting = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);

    }
}
