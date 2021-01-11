using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void Start()
    {
        Time.timeScale = 1;
    }
    public void PlayGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
   }

      public void PlayTutorial()
   {
       SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
   }
    public void Quit()
    {
        Application.Quit();
    }

}
