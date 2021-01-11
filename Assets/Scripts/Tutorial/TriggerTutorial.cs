using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this tutorial check if given target collide with game object trigger
public class TriggerTutorial : Tutorial
{

    private bool isCurrentTutorial = false;

    [SerializeField] private Transform HitTarget;


    public override void CheckIfHappaning()
    {
        isCurrentTutorial = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isCurrentTutorial)
            return;

        if (other.transform == HitTarget)
        {

            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }
    }
}
