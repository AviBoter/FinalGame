using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushHim : MonoBehaviour
{
   
    public float power = 500f;
    // Start is called before the first frame update
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 pos = transform.position;
        Vector3 diff= other.gameObject.transform.position - pos;
        Vector3 dir = new Vector3();
        float curDistance = diff.sqrMagnitude;
        dir = diff;
        dir = dir.normalized;
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir * power);
            this.gameObject.GetComponent<Rigidbody>().AddForce(-dir * power);
        }
    }


    
     




    

}
