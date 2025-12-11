using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    public static bool IsPaused {get; private set; }
    private static float _PauseDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            PauseGame();
        }
    }

    
    public void PauseGame()
    {
        pauseMenu.enabled = true;
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        
    }
    public void ContinueGame()
    {
        pauseMenu.enabled = false;
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        
    }

   
     public static IEnumerator PauseGame2()
    {
        
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        yield return new WaitForSeconds(_PauseDuration);
       



    }
    public static IEnumerator ContinueGame2()
    {
        
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        yield return new WaitForSeconds(_PauseDuration);
    }

    public void ExitToMenu()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        
        SceneManager.LoadScene(0);
    }
}
