using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abstract script of Tutorial
public class Tutorial : MonoBehaviour
{
    public int Order;

    [TextArea(3,10)]
    public string Explanation;

    void Awake()
    {
        TutorialManager.Instance.Tutorials.Add(this);
    }

    public virtual void init(){ }

    public virtual void CheckIfHappaning() { }

}
