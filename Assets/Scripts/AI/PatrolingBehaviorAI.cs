using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



/**
 * this script is representing a AI patrol behaviour by using raycast and given layer generate walk points and set it to the nav mash agent
 * 
 */
public class PatrolingBehaviorAI : IBehaviorAI


{

    [Tooltip("Minimum time to wait at target between running to the next target")]
    [SerializeField] private float minWaitAtTarget = 0f;

    [Tooltip("Maximum time to wait at target between running to the next target")]
    [SerializeField] private float maxWaitAtTarget = 2f;

    [SerializeField]  private NavMeshAgent agent;
    [SerializeField] private float rotationSpeed = 5f;

    //A game object whose children have a Target component. Each child represents a target
    [SerializeField] private Transform targetFolder;

    private Target[] allTargets;

    [Header("For debugging")]
    [SerializeField] private Target currentTarget;
    [SerializeField] private float timeToWaitAtTarget = 0;

    //Patroling    
    [SerializeField]  private bool Patrol;


    public PatrolingBehaviorAI() {}

    public void setTargetFolder(Transform targetFolder)
    {
        this.targetFolder = targetFolder;
    }

    public void setNavAgent(NavMeshAgent agent)
    {
        this.agent = agent;
    }


    private void Start()
    {
        allTargets = targetFolder.GetComponentsInChildren<Target>(false); // get components in active children only
    }
    private void Update()
    {
        if(Patrol && targetFolder != null && agent != null) {
            if (agent.hasPath)
                FaceDestination();
            else
            {
                timeToWaitAtTarget -= Time.deltaTime;
                if (timeToWaitAtTarget <= 0)
                    // we are at the target find new target
                    SelectNewTarget();
            }
        }
    }



    private void SelectNewTarget()
    {
        // dont repeat target
        int random = Random.Range(0, allTargets.Length - 1) + 1;
        currentTarget = allTargets[random];
        if(agent.gameObject.GetComponent<TouchDetector>().IsTouching())
        agent.SetDestination(currentTarget.transform.position);
        timeToWaitAtTarget = Random.Range(minWaitAtTarget, maxWaitAtTarget);

    }

    public void Action(bool patrol)
    {
        if(agent.gameObject.GetComponent<TouchDetector>().IsTouching()) Patrol = patrol;
    }


    private void FaceDestination()
    {
        Vector3 directionToDestination = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToDestination.x, 0, directionToDestination.z));
        //transform.rotation = lookRotation; // Immediate rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed); // Gradual rotation
    }


}
