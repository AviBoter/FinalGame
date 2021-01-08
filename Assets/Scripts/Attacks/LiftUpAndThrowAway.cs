using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LiftUpAndThrowAway : MonoBehaviour
{

    public Transform OtherPlayer;
    public float Throwing_force = 100;
    private GameObject ThPlayer;
    bool lifted = false;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision o)
    {
        if (o.gameObject.tag == "RedDragon" || o.gameObject.tag == "Player")
        {
            ThPlayer = o.gameObject;
            if (!lifted && Input.GetKey(KeyCode.R) && !ThPlayer.GetComponentInChildren<PushForce>().Lift)
            {
                GetComponent<Rigidbody>().useGravity = false;
                this.gameObject.GetComponent<PushForce>().enabled = false;
                this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<PushForce>().enabled = false;
                this.transform.position = OtherPlayer.GetComponent<Transform>().position;
                this.transform.rotation = OtherPlayer.GetComponent<Transform>().rotation;
                this.transform.parent = GameObject.Find("Me").transform;
                lifted = true;
                ThPlayer.GetComponentInChildren<PushForce>().Lift = true;
            }

          }
            
        }

    private void Update()
    {
        if (lifted && Input.GetKey(KeyCode.R))
        {
            this.transform.parent = null;
            this.gameObject.GetComponent<PushForce>().enabled = true;
            this.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddRelativeForce(ThPlayer.GetComponent<Rigidbody>().velocity * Throwing_force);
            lifted = false;
            GetComponent<PushForce>().enabled = true;
            ThPlayer.GetComponentInChildren<PushForce>().Lift = false;
        }
    }

}
