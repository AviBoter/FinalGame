using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterThenABullet : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public int Speed = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > Speed)
            anim.Play("fly");
    }
}
