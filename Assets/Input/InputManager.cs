using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;

    private PlayerInput _PlayerInput;
    private InputAction _moveAction;

    private void Awake ()
    {
        _PlayerInput = GetComponent<PlayerInput>();

        _moveAction = _PlayerInput.actions["Move"];
    }
    
    
    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
    }
}
