using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour

{
    public Transform player;
    public int interpolationFramesCount = 45;
    public int distanceFromPlayer = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destPosition = player.position - transform.forward * distanceFromPlayer;

        transform.position = Vector3.Lerp(transform.position, destPosition, interpolationFramesCount);
    }
}
