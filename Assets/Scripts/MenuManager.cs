using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager

public class MenuManager : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..."); 
        Application.Quit();
    }
}

