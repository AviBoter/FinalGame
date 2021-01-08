using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomProjectiles : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    [Header("Explosion:")]
    public float explosionRange;
    public float explosionForce;

    [Header("Lifetime:")]
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;


    void Update()
    {

       // if (collisions >= maxCollisions) Explode();

        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0 ) Explode();
    }


    public void Explode()
    {

        Debug.Log("Explode");

        //Instantiate explosion if attatched
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            //Check for enemies and damage them
            Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
            Debug.Log(enemies);

            for (int i = 0; i < enemies.Length; i++)
            {

                //Add explosion force to enemies
                if (enemies[i].GetComponent<Rigidbody>())
                    enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange, 2f);
            }

            Destroy(gameObject);
        }

    }

    private void OnDrawGizmosSelected()
    {
        //visualize the explosion range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }

}
