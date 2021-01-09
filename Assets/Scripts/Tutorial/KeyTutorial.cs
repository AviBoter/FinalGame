using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is key tutorial script, order of pressed doesn't matter
// check if user press given keys
public class KeyTutorial : Tutorial


{

    //save those keys incase of reload
    public List<string> Keys = new List<string>();


    private List<string> tempKeys = new List<string>();
    public void Start()
    {
        deepCopyList();
    }

    // deepcopy keys list to tempKeys
    private void deepCopyList()
    {
        foreach (string s in Keys)
            tempKeys.Add(s.Trim());
    }

    public override void init()
    {
        deepCopyList();
    }


    public override void CheckIfHappaning()
    {
        for (int i = 0; i < tempKeys.Count; i++)
        {
            Debug.Log(Input.inputString);

            if (Input.inputString.Contains(tempKeys[i]))
            {
                tempKeys.RemoveAt(i);
                break;
            }
        }

        // load next Tutorial
        if (tempKeys.Count == 0)
            TutorialManager.Instance.CompletedTutorial();
    }
}
