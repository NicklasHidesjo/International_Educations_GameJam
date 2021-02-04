using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    bool walkedAway = false;
    bool idle = true;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimation(Vector3 direction)
    {
        if(direction == Vector3.zero)
        {
            animator.SetTrigger("Idle");
            idle = true;
        }
        else
        {
            idle = false;
        }
        if(direction.z > 0 || walkedAway && !idle)
        {
            animator.SetTrigger("Walk Back");
        }
        if(direction.z < 0 || !walkedAway && !idle)
        {
            animator.SetTrigger("Walk Front");
        }

        if (direction.z > 0)
        {
            walkedAway = true;
        }
        else if(direction.z < 0)
        {
            walkedAway = false;
        }
    }

}
