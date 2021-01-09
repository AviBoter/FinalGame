using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script coming after each tutorial
// wait for user ReloadKey to reload prev tutorial
// or wait for user nextKey for continue
public class SummerizeTutorial : Tutorial
{
    [SerializeField] private KeyCode reloadKey;

    [SerializeField] private KeyCode nextKey;

    [SerializeField] private Transform player;

    [SerializeField] private Tutorial Prevtutorial_Script;

    private Vector3 PlayerStartPos;

    public void Start()
    {
        PlayerStartPos = player.position;
    }

    public override void CheckIfHappaning()
    {
        if (Input.GetKeyDown(reloadKey))
        {
            Prevtutorial_Script.init();
            player.position = PlayerStartPos;
            TutorialManager.Instance.ReloadPrevTutorial();
        }
        else if (Input.GetKeyDown(nextKey))
            TutorialManager.Instance.CompletedTutorial();
    }
}
