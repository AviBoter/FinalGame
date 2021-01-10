using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingAnime : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rig;
    private TouchDetector td;
    public KeyCode Kickkey;
    public KeyCode Upkey;
    public KeyCode Downkey;
    public KeyCode Jumpkey;
    public KeyCode Leftkey;
    public KeyCode Rightkey;


    void Start()
    {
        anim = GetComponent<Animator>();

        rig = GetComponent<Rigidbody>();
        td = GetComponent<TouchDetector>();
    }

    void Update()
    {
        //anim.SetBool("fall", !td.IsTouching() && !anim.GetBool("walk"));

        anim.SetBool("jump", Input.GetKey(Jumpkey));
        // anim.SetBool("throw", Input.GetKey(KeyCode.T));
        if (Input.GetKey(Upkey) && rig.gameObject.GetComponent<TouchDetector>().IsTouching())
            anim.Play("walk");
        if (Input.GetKeyDown(Kickkey))
        anim.Play("kick");
        anim.SetBool("backwalk", Input.GetKey(Downkey));
        anim.SetBool("left", Input.GetKey(Leftkey));
        anim.SetBool("right", Input.GetKey(Rightkey));

        
    }

}
