using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// this script check for change in velocty
public class readForce : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody rb;
    private Animator animator;

    [SerializeField] private float veloctyBlock = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < veloctyBlock)
        {
            agent.enabled = true;
            animator.SetBool("walk", true);
        }
        else 
        {
            agent.enabled = false;

        }
    }
}
