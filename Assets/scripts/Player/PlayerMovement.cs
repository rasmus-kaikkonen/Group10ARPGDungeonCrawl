using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movespeed = 5f;

    private Vector2 _movement;

    private Vector2 _dash;

    private Rigidbody2D _rb;
    private Animator _animator;
    

    [Header("Dash Settings")]
    [SerializeField] private float _dashSpeed = 10f;
    [SerializeField] private float _dashDuration = 1f;
    [SerializeField] private float _dashCooldown = 1f;
    bool isDashing = false;
    bool canDash = true;
    public bool canMove = true;

    

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    

    void Update()
    {
        if(!canMove || PauseMenu.IsPaused)
        {
           if(_rb.linearVelocity != Vector2.zero)
            {
                _rb.linearVelocity = Vector2.zero;
                _animator.SetFloat(_horizontal, 0);
                _animator.SetFloat(_vertical, 0);
                return; 
            } 
            
        }
        
        if(isDashing)
        {
            return;
        }
        
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        
        _rb.linearVelocity = _movement * _movespeed;
       

        _animator.SetFloat(_horizontal, _movement.x);
        _animator.SetFloat(_vertical, _movement.y);
        

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, _movement.x);
            _animator.SetFloat(_lastVertical, _movement.y);
            
            
        }

        if(Keyboard.current[Key.Space].wasPressedThisFrame && canDash)
        {
            
            StartCoroutine(Dash());
        }

       
    }

    
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        _dash.Set(InputManager.Movement.x , InputManager.Movement.y);
        _rb.linearVelocity = _dash * _dashSpeed;
        yield return new WaitForSeconds(_dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(_dashCooldown);
        canDash = true;
        
    }

    
    
}
