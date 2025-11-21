using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Escape].isPressed)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        isPaused = true;
    }
    public void ContinueGame()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
        isPaused = true;
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
