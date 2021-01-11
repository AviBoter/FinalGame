using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


// this script check for change in velocty
public class readForce : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody rb;
    private Animator animator;

    [SerializeField] private float veloctyBlock = 4f;
    [SerializeField] private float TooHigh = 115f;
    [SerializeField] private float URout = 120f;
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

        if(rb.transform.position.y> TooHigh)
        {
            animator.Play("fall");
            if (rb.transform.position.y > URout)
                Destroy(rb.gameObject);
        }
        if (rb.velocity.magnitude < veloctyBlock)
        {
            agent.enabled = true;
            animator.SetBool("walk", true);
        }
        else 
        {
            animator.SetBool("walk", false);
            agent.enabled = false;

        }
    }
}
