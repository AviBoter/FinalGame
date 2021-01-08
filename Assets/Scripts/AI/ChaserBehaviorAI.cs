using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/**
 * this script is representing a AI Chaser behavior, using navmesh agent to set destintaion on player position
 * 
 */
public class ChaserBehaviorAI : IBehaviorAI

{
    [SerializeField] private NavMeshAgent agent;
    public ChaserBehaviorAI() {}

    public void setNavAgent(NavMeshAgent agent)
    {
        this.agent = agent;
    }
    public void Action(Transform player) {

        if (agent.gameObject.GetComponent<TouchDetector>().IsTouching())
            agent.SetDestination(player.position);
    }
}
