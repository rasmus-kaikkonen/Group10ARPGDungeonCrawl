using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatusMenu : MonoBehaviour
{
    [SerializeField] Canvas statusMenu;
    [field: SerializeField] public bool StatusMenuOpen {get; set;} = false;

    void Update()
    {
        if(Keyboard.current[Key.I].wasPressedThisFrame)
        {
            OpenStatusMenu();
        }
    }

    public void OpenStatusMenu()
    {
        statusMenu.enabled = true;
        StatusMenuOpen = true;
    }

    public void CloseStatusMenu()
    {
        statusMenu.enabled = false;
        StatusMenuOpen = false;
    }
}
