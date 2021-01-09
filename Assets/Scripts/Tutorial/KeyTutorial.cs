using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is key tutorial script, order of pressed doesn't matter
public class KeyTutorial : Tutorial
{
    public List<string> Keys = new List<string>();

    public override void CheckIfHappaning()
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (Input.inputString.Contains(Keys[i]))
            {
                Keys.RemoveAt(i);
                break;
            }
        }

        // load next Tutorial
        if (Keys.Count == 0)
            TutorialManager.Instance.CompletedTutorial();
    }
}
