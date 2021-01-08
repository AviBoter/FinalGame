using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchFire : MonoBehaviour
{
    public float power = 2232f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("  ttttttttttt");
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * power);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
