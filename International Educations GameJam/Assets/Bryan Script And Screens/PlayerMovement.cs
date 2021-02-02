using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerSciptObject m_Stats; // makes a refrence to the playerScriptObject

    Rigidbody2D RB; // gets Rigidbody in start

    private Vector2 MoveDir; // gets the move Dir 


    public void Start()
    {
        RB = GetComponent<Rigidbody2D>(); // calls the RB on startup
    }



    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        MoveDir = new Vector2(moveX, moveY); // gets the dir from the Horizontal and vertical inputs

    }

    void MovePlayer()
    {
        RB.velocity = new Vector2(MoveDir.x * m_Stats.MoveSpeed, MoveDir.y * m_Stats.MoveSpeed);
        // makes the rigitbody move 
    }
}
