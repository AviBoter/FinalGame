using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class kickHim : MonoBehaviour

{

    [SerializeField] float rayLength = 100f;
    [SerializeField] float rayDuration = 1f;
    [SerializeField] Color rayColor = Color.black;
    [SerializeField] Camera camera = null;
    [SerializeField] KeyCode KickKey;
    public float gunForce = 30f;
    public ForceMode walkForceMode;
    Transform me;
    //private NavMeshAgent nav;


    // Start is called before the first frame update
    void Start()
    {
        walkForceMode = ForceMode.Impulse;
    }

    // Update is called once per frame
    void Update()
    {
        me = GetComponent<Transform>();
        if (Input.GetKeyDown(KickKey))
        {
            
            //position ray casted from
            
            RaycastHit hitInfo;
            if (Physics.Raycast(me.position,me.forward, out hitInfo))
            {
                if (hitInfo.rigidbody != null)
                {
                    hitInfo.rigidbody.gameObject.GetComponent<Animator>().Play("kicked");
                    if(hitInfo.rigidbody.gameObject.GetComponent<NavMeshAgent>())
                        hitInfo.rigidbody.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    hitInfo.rigidbody.AddForce(-hitInfo.normal * gunForce, walkForceMode);
                }
                Debug.Log("ray hits: " + hitInfo.transform.name);
            }
        }

    

        

    }
}
