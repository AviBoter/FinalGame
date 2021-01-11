using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TooHigh : MonoBehaviour
{
    [SerializeField] private float height = 115f;
    [SerializeField] private float URout = 120f;
    private Rigidbody rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rbody.transform.position.y > height)
        {
            rbody.gameObject.GetComponent<Animator>().Play("fall");
            if (rbody.transform.position.y > URout)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
