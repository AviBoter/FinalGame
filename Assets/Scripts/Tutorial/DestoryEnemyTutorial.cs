using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this tutorial instantiate an enemy, and check if player destory him (pushed him off the edge)
public class DestoryEnemyTutorial : Tutorial
{
    [SerializeField] private GameObject enemy;

    private GameObject TempEnemy;

    private bool enemyAlive = false;


    public override void init()
    {
        TempEnemy = instantiateEnemy();
        TempEnemy.SetActive(true);


    }

    private GameObject instantiateEnemy() 
    {
        if (enemy == null)
            throw new System.Exception("This script must have enemy");

        return Instantiate(enemy, enemy.transform.position, Quaternion.identity);
    }


    public GameObject getEnemy()
    {
        return TempEnemy;
    }


    public override void CheckIfHappaning()
    {
        if (!enemyAlive && TempEnemy == null)
        {
            init();
            enemyAlive = true;
        }
        // enemy destoryed
        else if (TempEnemy == null)
        {
            enemyAlive = false;
            TutorialManager.Instance.CompletedTutorial();
        }

    }
}
