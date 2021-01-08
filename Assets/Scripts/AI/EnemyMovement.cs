using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this component recive an enemy transform and chase his direction

public class EnemyMovement : MonoBehaviour
{



    public float moveSpeed = 5f;
    public Transform enemy;
    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.gameObject.scene.IsValid())
        {
            Vector3 direction = enemy.position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            rb.rotation = Quaternion.Euler(0f, angle, 0f);
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }
    void MoveCharacter(Vector3 direction)
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
