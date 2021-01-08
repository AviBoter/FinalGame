using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this component recive an list of enemies and find the closest one using Vector3.Distance
// then update EnemyMovement closest target


[RequireComponent(typeof(EnemyMovement))]
public class ClosestEnemy : MonoBehaviour
{
    private Transform Player;

    public List<Transform> EnemyList;

    private Transform nearestEnemy;

    void Start()
    {
        Player = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        float minimumDistance = Mathf.Infinity;

        nearestEnemy = null;
        foreach (Transform enemy in EnemyList)
        {
            if (enemy != null)
            {
                float distance = Vector3.Distance(Player.position, enemy.position);
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    nearestEnemy = enemy;
                }
            }
            else 
                EnemyList.Remove(enemy);
            
        }
        StartCoroutine(waiter());
        gameObject.GetComponent<EnemyMovement>().enemy = nearestEnemy;
    }
    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);

    }
}