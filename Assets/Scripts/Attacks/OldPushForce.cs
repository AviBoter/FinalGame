using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPushForce : MonoBehaviour
{

    private Vector3 velocty;
    private Rigidbody rbody;
    private Transform tform;
    [SerializeField]
    private ForceMode force_mode;
    [SerializeField]
    private float Force_Level = 15;


    // Start is called before the first frame update
    void Start()
    {

        rbody = gameObject.GetComponent<Rigidbody>();
        tform = gameObject.GetComponent<Transform>();

    }


    void OnCollisionEnter(Collision other)
    {

        if (enabled && (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"))
        {
            Debug.Log("got here");
            Debug.Log(other.gameObject.tag);
            other.rigidbody.AddForce(transform.forward * Force_Level, force_mode);
        }
    }

}