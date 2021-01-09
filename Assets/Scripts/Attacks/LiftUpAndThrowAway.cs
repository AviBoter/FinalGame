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
        if ( o.gameObject.tag == "Player")
        {
            ThPlayer = o.gameObject;
            if (!lifted && Input.GetKey(KeyCode.R) && !ThPlayer.GetComponentInChildren<PushForce>().Lift)
            {
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                this.gameObject.GetComponent<Animator>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                this.gameObject.GetComponent<PushForce>().enabled = false;
                this.gameObject.GetComponent<TouchDetector>().enabled = false;
                this.gameObject.GetComponent<BehaviorAIController>().enabled = false;
                this.gameObject.GetComponent<PushForce>().enabled = false;
                this.gameObject.GetComponent<FasterThenABullet>().enabled = false;
                this.gameObject.GetComponent<Freezed>().enabled = false;
                this.transform.parent = GameObject.Find("Me").transform;
                lifted = true;
                ThPlayer.GetComponentInChildren<PushForce>().Lift = true;
            }

          }
            
        }

    private void Update()
    {
        bool thorow = false;
        if (lifted)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            this.gameObject.GetComponent<CapsuleCollider>().radius = 0.0001f;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Animator>().enabled = true;
            this.gameObject.GetComponent<Animator>().Play("Captured");
            thorow = true;
        }

        if (lifted && Input.GetKeyDown(KeyCode.T)) { 
         GetComponent<Rigidbody>().useGravity = true;
         this.gameObject.GetComponent<PushForce>().enabled = true;
         this.gameObject.GetComponent<TouchDetector>().enabled = true;
            this.gameObject.GetComponent<NavMeshAgent>().enabled = true;
            this.gameObject.GetComponent<BehaviorAIController>().enabled = true;
         this.gameObject.GetComponent<PushForce>().enabled = true;
         this.gameObject.GetComponent<FasterThenABullet>().enabled = true;
         this.gameObject.GetComponent<Freezed>().enabled = true;
         ThPlayer.GetComponentInChildren<PushForce>().Lift = false;
         GetComponent<Rigidbody>().AddRelativeForce(ThPlayer.GetComponent<Rigidbody>().velocity * Throwing_force);
            this.gameObject.GetComponent<Animator>().enabled = true;
            lifted = false;
            GetComponent<PushForce>().enabled = true;
            ThPlayer.GetComponentInChildren<PushForce>().Lift = false;
        }
    }

}
