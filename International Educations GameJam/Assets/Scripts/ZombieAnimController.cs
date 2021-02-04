using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 direction = navMeshAgent.velocity;
        if (direction.z == 0 && direction.x == 0)
        {
            anim.SetTrigger("Idle");
        }
        if(direction.z < 0)
        {
            anim.SetTrigger("Walk Front");
        }
        else
        {
            anim.SetTrigger("Walk Back");
        }
    }
}
