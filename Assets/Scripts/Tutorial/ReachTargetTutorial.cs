using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script check if user Hit given object using distance
public class ReachTargetTutorial : Tutorial
{
    public Transform targetTransfrom;
    public Transform playerTransfrom;

    private float eps = 3f;

    public override void CheckIfHappaning()
    {
        float distance = Vector3.Distance(targetTransfrom.position, playerTransfrom.position);
        Debug.Log(distance);
        if (distance <= eps) 
        {
            TutorialManager.Instance.CompletedTutorial();
        }
    }
}
    