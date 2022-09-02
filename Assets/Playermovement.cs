using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Playermovement : MonoBehaviour
{
    [SerializeField] InputActionReference _MoveInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float _speed;
    [SerializeField] Animator _animator;
    [SerializeField] float _MovingThreshold;

    // Start is called before the first frame update

    void Start()
    {
        _MoveInput.action.started += StarMove;
        _MoveInput.action.performed += UdpateMove;
        _MoveInput.action.canceled += EndMove;
    }

    private void EndMove(InputAction.CallbackContext obj)
    {
   
    }

    private void UdpateMove(InputAction.CallbackContext obj)
    {
        
    }

    private void StarMove(InputAction.CallbackContext obj)
    {
        
    }
    void Update()
    {
        Vector2 moveInput = _MoveInput.action.ReadValue<Vector2>();

        if (moveInput.magnitude > _MovingThreshold)  // si on est ent train de bouger alors 
        {
            _animator.SetBool("Iswalking", true);
            _animator.SetFloat("Horrizontal", moveInput.x);
            _animator.SetFloat("Vertical", moveInput.y);
        }
        else
        {                 //sinon c'est qu'on bouge pas donc false
            _animator.SetBool("Iswalking", false);
        }


    }
    void FixedUpdate()
    {
        Vector2 moveInput = _MoveInput.action.ReadValue<Vector2>();
        rb.velocity = moveInput * _speed;
    }
}
   