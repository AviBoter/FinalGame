using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// this script used for manage tutorials
public class TutorialManager : MonoBehaviour
{

    
    public List<Tutorial> Tutorials = new List<Tutorial>();

    // explantion text of current Tutorial
    public Text expText;

    private static TutorialManager instance;

    // create only single instance to manage the scene
    public static TutorialManager Instance
    {

        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            if (instance == null)
                Debug.Log("No tutorial manager");

            return instance;
        }
        
    }

    private Tutorial currentTutorial;


    // Start is called before the first frame update
    void Start()
    {
        SetNextTutorial(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial)
            currentTutorial.CheckIfHappaning();
    }

    public void CompletedTutorial()
    {
        SetNextTutorial(currentTutorial.Order + 1);
    
    }

    public void ReloadPrevTutorial()
    {
        SetNextTutorial(currentTutorial.Order - 1);

    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = GetTutorialByOrder(currentOrder);

        // no more tutorials
        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }

        expText.text = currentTutorial.Explanation;
    }


    public void CompletedAllTutorials()
    {
        expText.text = "You have completed all the tutorials";

        // load back menu 
    }

    // we must go in loop because we dont know the Order
    public Tutorial GetTutorialByOrder(int Order)
    {
        for (int i = 0; i < Tutorials.Count; i++) {

            if (Tutorials[i].Order == Order)
                return Tutorials[i];
        }

        return null;
    }



}
