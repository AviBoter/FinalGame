using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class changeText : MonoBehaviour
{
    [SerializeField] DestroyOnTrigger distroyScript;
    [SerializeField] GameObject Tree;
    private Text text;
    
    [SerializeField] int enemy;


    void Start()
    {
        Tree.SetActive(false);
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "enemy to push away: " + (enemy-distroyScript.getCount());
        if(enemy- distroyScript.getCount() == 0)
        {
            Tree.SetActive(true);
           
            text.text = "graet!! mow go to the "+Tree.gameObject.name;
        }
    }
}
