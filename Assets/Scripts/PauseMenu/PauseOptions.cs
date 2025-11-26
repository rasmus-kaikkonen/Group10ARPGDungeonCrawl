using UnityEngine;

public class PauseOptions : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] Canvas optionsMenu;
    public void ReturnToPauseMenu()
    {
        optionsMenu.enabled = false;
        pauseMenu.enabled = true;
    }
    public void FromPauseToOptions()
    {
        optionsMenu.enabled = true;
        pauseMenu.enabled = false;
    }
}
