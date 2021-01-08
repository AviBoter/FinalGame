using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyFromArena : MonoBehaviour

{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
