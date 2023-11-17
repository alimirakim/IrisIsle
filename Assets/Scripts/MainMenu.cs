using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  string gameSceneName = "PlantScene";
  
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    
    public void QuitGame()
    {
      Debug.Log("Quitting Game...");
      Application.Quit();
    }
}
