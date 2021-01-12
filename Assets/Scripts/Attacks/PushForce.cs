using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class PushForce : MonoBehaviour
{

    private Vector3 velocty;
    private Rigidbody rb;
    public bool Lift;
    private Transform tf;
    [SerializeField]
    private ForceMode forcemode;
    [SerializeField]
    private float ForceLevel = 15;
   


    // Start is called before the first frame update
    void Start()
    {
        
        Collider col = gameObject.GetComponent<Collider>();
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
        Lift = false;
    }


    IEnumerator OnCollisionEnter(Collision other)
    {

        if (enabled && (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"))
        {
            if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<NavMeshAgent>().isActiveAndEnabled && other.gameObject != null)
            {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().isKinematic = false;
                GameObject go = other.gameObject;
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                if(other.gameObject.tag != "Bullet")
                other.gameObject.GetComponent<Animator>().Play("pushed");
                rb.useGravity = false;
                other.rigidbody.AddForce(transform.forward * ForceLevel, forcemode);
                yield return new WaitForSeconds(1f);
                if(rb)
                rb.useGravity = true;
            }
            
             else
                if (!Input.GetKey(KeyCode.F))
            {
                other.gameObject.GetComponent<Animator>().Play("pushed");
                other.rigidbody.AddForce(transform.forward * ForceLevel, forcemode);
               
            }
           

        }

    }


    private bool isGruonded()
    {
        return rb.gameObject.GetComponent<TouchDetector>().IsTouching();
    }
}
