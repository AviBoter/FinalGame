using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This component freeze enemy controller for few sec
 */
public class Freezed : MonoBehaviour
{

    private bool IsFreezed;
    private BehaviorAIController AIcontroller;
    [SerializeField] private float FreezeTime = 1f;
    [Tooltip("the script will use this gameobject to render is color")]
    [SerializeField] private GameObject GameoObject_OnFreeze;
    [SerializeField] private Material OriginMaterial;
    [SerializeField] private Material MatrialOnFreeze;


    public bool getIsFreezed() {
        return IsFreezed;
    }

    public void setIsFreezed(bool freeze)
    {
        IsFreezed = freeze;
    }
    // Start is called before the first frame update
    void Start()
    {
        AIcontroller = gameObject.GetComponent<BehaviorAIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFreezed)
        {
            AIcontroller.enabled = false;
            GameoObject_OnFreeze.GetComponent<SkinnedMeshRenderer>().material = MatrialOnFreeze;
            StartCoroutine(warmUp(FreezeTime));
        }
        else {
            AIcontroller.enabled = true;
            GameoObject_OnFreeze.GetComponent<SkinnedMeshRenderer>().material = OriginMaterial;
        }

    }

    IEnumerator warmUp(float delayTime)
    {

        yield return new WaitForSeconds(delayTime);
        setIsFreezed(false);

    }


}
