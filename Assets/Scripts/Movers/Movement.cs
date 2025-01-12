﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/**
 * This component is for moving, jump, dash the charcther by his rigidbody
 * also using touchDetector to achive jump ability by knowing when he is on the ground
 * 
 */


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TouchDetector))]
public class Movement : MonoBehaviour
{

    [Tooltip("The horizontal force that the player's feet use for walking, in newtons.")]
    [SerializeField] private float Speed = 5f;

    [Tooltip("The vertical force that the player's feet use for jumping, in newtons.")]
    [SerializeField] float jumpImpulse = 5f;

    [SerializeField] private float DashDistance = 5f;


    [SerializeField] private KeyCode Jumpkey;
    [SerializeField] private KeyCode Dashkey;
   

    [Range(0, 1f)]
    [SerializeField] float slowDownAtJump = 0.5f;

    [Range(0, 1f)]
    [SerializeField] float slowDownAtWalk = 0.95f;

    [Range(0, 1f)]
    [SerializeField] float dashDrag = 0.5f;


    private Rigidbody rbody;

    // user keyboard inputs
    private Vector3 inputs = Vector3.zero;

    private TouchDetector td;
    private bool playerWantsToJump = false;
    private bool playerWantsToDash = false;

    void Start()
    {
        td = GetComponent<TouchDetector>();
        rbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        

        // Keyboard events are tested each frame, so we should check them here.
        if (Input.GetKeyDown(Jumpkey))
            playerWantsToJump = true;

        if (Input.GetKeyDown(Dashkey))
            playerWantsToDash = true;        
    }

    void FixedUpdate()
    {

        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.z = Input.GetAxis("Vertical");


        if (playerWantsToDash)
        {
            rbody.gameObject.GetComponent<Animator>().Play("dash");

            Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3(dashDrag, 0, dashDrag));
            rbody.AddForce(dashVelocity, ForceMode.Impulse);
            playerWantsToDash = false;

        }

        // move player
        inputs = transform.TransformDirection(inputs);
        if (Input.GetAxis("Horizontal") != 0)
        {
            
            rbody.MovePosition(rbody.position + inputs * Speed * Time.fixedDeltaTime);
        }
        if(Input.GetAxis("Horizontal").Equals(0))
        {
            
            rbody.MovePosition(rbody.position + inputs * Speed * Time.fixedDeltaTime);
        }

        if (td.IsTouching())
        {  // allow to walk and jump 
            if (playerWantsToJump)
            {            // Since it is active only once per frame, and FixedUpdate may not run in that frame!
                rbody.velocity = new Vector3(rbody.velocity.x * slowDownAtJump, rbody.velocity.y, rbody.velocity.z);
                rbody.AddForce(new Vector3(0, jumpImpulse, 0), ForceMode.Impulse);
                playerWantsToJump = false;
            }
        }
    }
}

