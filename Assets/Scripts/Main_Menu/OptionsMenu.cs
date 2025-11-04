using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public Canvas mainMenu;
    public Canvas optionsMenu;
    public AudioMixer audioMixer;

    public void GoBackToMainMenu()
    {
        mainMenu.enabled = true;
        optionsMenu.enabled = false;
    }
}
