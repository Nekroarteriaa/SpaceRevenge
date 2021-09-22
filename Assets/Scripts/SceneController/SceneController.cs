using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   public void OnReloadScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void OnMenuLoad()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGameStart()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnGameExit()
    {
        Application.Quit();
    }
}
