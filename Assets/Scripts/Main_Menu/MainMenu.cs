using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenu;
    public Canvas optionsMenu;
    public void LoadTestScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToOptions()
    {
        mainMenu.enabled = false;
        optionsMenu.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
