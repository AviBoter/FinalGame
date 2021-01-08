using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToAreana : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro winnerText;
   

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggeringTag && enabled)
        { 
            nextLevel();
        }

    }

    private void nextLevel()
    {

         if (SceneManager.GetActiveScene().buildIndex < 7 )
         {
             Debug.Log("new scene");
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
         else
         {
             Debug.Log("win");
             // player won
             Time.timeScale = 0;
             winnerText.text = "You win \n Great Job!";
         }

       
    }

    

}

