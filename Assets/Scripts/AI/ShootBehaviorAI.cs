using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/**
 * this script is representing a AI Shoot behavior that instantiate attack on player by given projectile to throw
 */

public class ShootBehaviorAI : IBehaviorAI
{
    private NavMeshAgent agent;
    private bool AlreadyShoot; 
    [SerializeField] private float cooldownTime = 2f;
    
    public ShootBehaviorAI() {}

    public void setNavAgent(NavMeshAgent agent) {
        this.agent = agent;
    }


    public void Action(Transform player, Transform me, float shotPowerFoward, float shotPowerUp, GameObject projectile, MonoBehaviour monobehaviour, bool isGrounded)
    {

        //Make sure enemy doesn't move while shoot
        if (me.gameObject.GetComponent<TouchDetector>().IsTouching())
            agent.SetDestination(me.position);

        me.LookAt(player);

        if (!AlreadyShoot) {

            AlreadyShoot = true;
            Rigidbody rb = Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * shotPowerFoward, ForceMode.Impulse);
            rb.AddForce(transform.up * shotPowerUp, ForceMode.Impulse);

            monobehaviour.StartCoroutine(Shoot(cooldownTime));

        }
    }
    IEnumerator Shoot(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        AlreadyShoot = false;
    }


}





