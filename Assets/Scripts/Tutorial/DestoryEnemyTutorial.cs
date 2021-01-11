using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemyTutorial : Tutorial
{
    //save those keys incase of reload
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
