using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this tutorial check if given target collide with game object trigger
public class TriggerTutorial : Tutorial
{

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private bool isCurrentTutorial = false;

    [SerializeField] private GameObject hitTarget;


    public override void CheckIfHappaning()
    {
        isCurrentTutorial = true;
        hitTarget.SetActive(true);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isCurrentTutorial)
            return;

        if (other.tag == triggeringTag && enabled)
        {

            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
            hitTarget.SetActive(false);

        }
    }
}
