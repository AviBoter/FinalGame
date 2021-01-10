using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



/**
 * this is script represent AI controller include 3 behaviors of AI patrol , Chase and Shot/Attack
 */
public class BehaviorAIController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rb;

    // what is the target of this AI
    [SerializeField] private Transform player;

    //Check for Ground/Obstacles
    [SerializeField] private LayerMask LayerPlayer;

    //Patroling
    [SerializeField] private Transform targetFolder;


    //Shot Player
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float shotPowerFoward = 32f;
    [SerializeField] private float shotPowerUp = 8f;
    [SerializeField] private GameObject projectile;



    //States
    [SerializeField] private float sightRange, attackRange, shootRange;

    private bool InSightRange, InAttackRange, InShootRange;

    // behaviours;
    private ShootBehaviorAI shootBehavior;
    private ChaserBehaviorAI chaserBehavior;
    private PatrolingBehaviorAI patrolBehavior;
    


    private void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

        if (targetFolder != null)
        {

            patrolBehavior = gameObject.AddComponent<PatrolingBehaviorAI>();
            patrolBehavior.setNavAgent(agent);
            patrolBehavior.setTargetFolder(targetFolder);
        }
        // add to child(2) shootingArea.gameobject
        shootBehavior = transform.GetChild(2).gameObject.AddComponent<ShootBehaviorAI>(); // new ShootBehaviorAI(agent, coll, transform);
        shootBehavior.setNavAgent(agent);


        chaserBehavior = gameObject.AddComponent<ChaserBehaviorAI>();
        chaserBehavior.setNavAgent(agent);
    }
    private void FixedUpdate()
    {
        //Check if Player in sight range
        InSightRange = Physics.CheckSphere(transform.position, sightRange, LayerPlayer);

        //Check if Player in shoot range
        InShootRange = Physics.CheckSphere(transform.position, shootRange, LayerPlayer);

        //Check if Player in attack range
        InAttackRange = Physics.CheckSphere(transform.position, attackRange, LayerPlayer);


      


        if (agent.isActiveAndEnabled == true && isGrounded())
        {
            if (targetFolder != null)
            {
                // if Ai in shot range then he is in attack range
                if (!InSightRange && !InShootRange)
                {
                    patrolBehavior.Action(true);

                }
                else
                {
                    patrolBehavior.Action(false);

                }

            }

            if (InSightRange && !InShootRange){ 
                chaserBehavior.Action(player);
            }
            if (InSightRange && InShootRange && !InAttackRange)
            {
                shootBehavior.Action(player, transform, shotPowerFoward, shotPowerUp, projectile, this, isGrounded());
            }
            if (InSightRange && InShootRange && InAttackRange)
            chaserBehavior.Action(player);
        }


        

    }

    private bool isGrounded()
    {
        return rb.gameObject.GetComponent<TouchDetector>().IsTouching();
    }

    private void OnDrawGizmos()
    {
        // sight
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        // shoot
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootRange);
        // attack by push and chase
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);


    }

}
