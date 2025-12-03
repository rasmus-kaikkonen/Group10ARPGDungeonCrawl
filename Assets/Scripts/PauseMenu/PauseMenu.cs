using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    public static bool IsPaused {get; private set; }

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
    public void ExitToMenu()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0f : 1f;
        SceneManager.LoadScene(0);
    }
}
