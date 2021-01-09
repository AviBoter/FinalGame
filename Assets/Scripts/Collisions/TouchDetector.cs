using UnityEngine;


/**
 *  This component checks whether its object touches a collider of a given kind.
 *  Works with a 3D RigidBody.
 */
[RequireComponent(typeof(Rigidbody))]
public class TouchDetector : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    [Header("This field is for display only")]
    [SerializeField] private int touchingColliders = 0;

    private Rigidbody rbody;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( (layerMask.value & (1 << collision.gameObject.layer)) > 0)
            touchingColliders++;
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((layerMask.value & (1 << collision.gameObject.layer)) > 0)
            touchingColliders--;
    }

    public bool IsTouching()
    {
        return touchingColliders > 0;
    }
}