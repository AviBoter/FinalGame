using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kickHim : MonoBehaviour
{
    [SerializeField] KeyCode KickKey;
    public float kickForce = 150f;
    public float kickRange = 40f;

    private float upwardsModifer = 2f;
    Transform me;


    // Update is called once per frame
    void Update()
    {
        me = GetComponent<Transform>();
        if (Input.GetKeyDown(KickKey))
        {

            //position ray casted from

            RaycastHit hitInfo;
            if (Physics.Raycast(me.position, me.forward, out hitInfo))
            {
                if (hitInfo.rigidbody != null)
                {
                    hitInfo.rigidbody.gameObject.GetComponent<Animator>().Play("kicked");
                    hitInfo.rigidbody.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    // upwardsModifer is adviced to be 2f 
                    hitInfo.rigidbody.AddExplosionForce(kickForce, transform.position, kickRange, upwardsModifer);

                    //hitInfo.rigidbody.AddForce(-hitInfo.normal * gunForce, walkForceMode);

                    Debug.Log("ray hits: " + hitInfo.transform.name);
                }
            }





        }
    }
}

