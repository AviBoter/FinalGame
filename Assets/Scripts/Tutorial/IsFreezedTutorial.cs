using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this tutorial instantiate an enemy, and check if player destory him (pushed him off the edge)
// and he been freezed

public class IsFreezedTutorial : DestoryEnemyTutorial
{

    private Freezed freezeComponent;

    private bool firstTime = true;
    private bool playerFreezedTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        freezeComponent = gameObject.GetComponent<Freezed>();
    }

    public override void init()
    {
        base.init();
        freezeComponent = base.getEnemy().GetComponent<Freezed>();
        firstTime = true;
}


public override void CheckIfHappaning()
    {

        // enemy may not Instantiate yet
        if (!firstTime && !playerFreezedTarget)
            playerFreezedTarget = freezeComponent.getIsFreezed();


        if (playerFreezedTarget && base.getEnemy() == null)
        {
            TutorialManager.Instance.CompletedTutorial();
            firstTime = true;
            playerFreezedTarget = false;

        }

        // init enemy
        else if (base.getEnemy() == null)
        {
            // create enemy
            init();
            firstTime = false;
            return;
        }
    }
}
