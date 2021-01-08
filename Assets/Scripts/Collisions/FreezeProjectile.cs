using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FreezeProjectile : MonoBehaviour
{

    [SerializeField] private GameObject Freeze;
    [SerializeField] private LayerMask whatIsEnemies;

    [Header("Freeze:")]
    [SerializeField] private float FreezeRange;

    [Header("Lifetime:")]
    [SerializeField] private float maxLifetime;


    void Update()
    {

        // if (collisions >= maxCollisions) Explode();

        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }


    public void Explode()
    {

        Debug.Log("Explode");

        //Instantiate explosion if attatched
        if (Freeze != null)
        {
            Instantiate(Freeze, transform.position, Quaternion.identity);

            //Check for enemies and damage them
            Collider[] enemies = Physics.OverlapSphere(transform.position, FreezeRange, whatIsEnemies);
            Debug.Log(enemies);

            for (int i = 0; i < enemies.Length; i++)
            {
                Debug.Log(enemies[i].tag);

                //Add explosion force to enemies
                if (enemies[i].GetComponent<BehaviorAIController>())
                {
                    enemies[i].GetComponent<Freezed>().setIsFreezed(true);
                }
            }
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmosSelected()
    {
        //visualize the explosion range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FreezeRange);
    }

}
