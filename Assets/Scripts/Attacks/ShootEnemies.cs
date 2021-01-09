using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    private CapsuleCollider coll;
    private bool alreadyShoot = false;

    [SerializeField] private KeyCode ShootKey;
    [SerializeField] private float shotPowerFoward = 12f;
    [SerializeField] private float shotPowerUp = 8f;
    [SerializeField] private float timeBetweenAttacks = 1;
    [SerializeField] private GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        //coll = gameObject.GetComponent<CapsuleCollider>();
        //coll.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        // always reset after shooting
        //coll.isTrigger = false;

        if (Input.GetKeyDown(ShootKey)) {
            ShootEnemey();
        }
    }

    private void ShootEnemey()
    {
        //coll.isTrigger = true;

        if (!alreadyShoot){
            

            //Attack
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shotPowerFoward, ForceMode.Impulse);
            rb.AddForce(transform.up * shotPowerUp, ForceMode.Impulse);

            alreadyShoot = true;
            Invoke("ResetAttack", timeBetweenAttacks);
        }

    }
    private void ResetAttack()
    {
        alreadyShoot = false;
    }

}
