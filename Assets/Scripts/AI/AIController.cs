
using UnityEngine;
using UnityEngine.AI;


/**
 * this is script represent AI controller include 3 behaviors of AI patrol , Chase and Shot/Attack
 */
public class AIController : MonoBehaviour
{
    private NavMeshAgent agent;
    private CapsuleCollider coll;
    private Rigidbody rb;
    public Transform player;

    //Check for Ground/Obstacles
    public LayerMask Terrain, Player;

    // AI speed
    public float MovementSpeed = 5f;

    //Patroling
    private Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;
    public int maxSearchDistance = 2;

    //Shot Player
    public float timeBetweenAttacks;
    private bool alreadyShoot;
    public float shotPowerFoward = 32f;
    public float shotPowerUp = 8f;
    public GameObject projectile;


    //States
    public float sightRange, attackRange, shootRange;
    private bool InSightRange, InAttackRange, InShootRange;

    
    private void Start()
    {
        coll = GetComponent<CapsuleCollider>();
        coll.isTrigger = false;
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        agent.speed = MovementSpeed;

        coll.isTrigger = false;
        //Check if Player in sight range
        InSightRange = Physics.CheckSphere(transform.position, sightRange, Player);

        //Check if Player in shoot range
        InShootRange = Physics.CheckSphere(transform.position, shootRange, Player);

        //Check if Player in attack range
        InAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        if (agent.isActiveAndEnabled==true && isGruonded())
        {
            // if Ai in shot range then he is in attack range
            if (!InSightRange && !InShootRange) Patroling();
            if (InSightRange && !InShootRange) ChasePlayer();
            if (InSightRange && InShootRange && !InAttackRange) ShootPlayer();
            if (InSightRange && InShootRange && InAttackRange) ChasePlayer();
        }
    }

    private void Patroling()
    {

        if (!walkPointSet && isGruonded()) SearchWalkPoint();

        //Calculate direction and walk to Point
        if (walkPointSet){
            agent.SetDestination(walkPoint);

        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,transform.up, maxSearchDistance, Terrain))
        walkPointSet = true;
    }
    private void ChasePlayer()
    {
        if(isGruonded())
        agent.SetDestination(player.position);

    }
    private void ShootPlayer()
    {
        coll.isTrigger = true;
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyShoot){
            

            //Attack
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * shotPowerFoward, ForceMode.Impulse);
            rb.AddForce(transform.up * shotPowerUp, ForceMode.Impulse);

            alreadyShoot = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }

    }
    private void ResetAttack()
    {
        alreadyShoot = false;
    }

    private bool isGruonded()
    {
        return rb.gameObject.GetComponent<TouchDetector>().IsTouching();
    }
}
