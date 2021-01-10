using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    private bool alreadyShoot = false;

    [SerializeField] private KeyCode ShootKey;
    [SerializeField] private float shotPowerFoward = 12f;
    [SerializeField] private float shotPowerUp = 8f;
    [SerializeField] private float timeBetweenAttacks = 5;
    [SerializeField] private GameObject projectile;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ShootKey)) {
            ShootEnemey();
        }
    }

    private void ShootEnemey()
    {

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
