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
    [SerializeField] InputActionReference _interraction;
    [SerializeField] InputActionReference _sprint;
    [SerializeField] float _vitesseSprint;
    public bool _isRunning;

    // Start is called before the first frame update

    void Start()
    {
        _MoveInput.action.started += StarMove;
        _MoveInput.action.performed += UdpateMove;
        _MoveInput.action.canceled += EndMove;

        _sprint.action.started += StarSprint;
        _sprint.action.canceled += EndSprint;




    }

    private void StarSprint(InputAction.CallbackContext obj)
    {
        _isRunning = true;
      //  _animator.SetBool("IsRunning", true);
    }
 
    private void EndSprint(InputAction.CallbackContext obj)
    {
        _isRunning = false;
    //    _animator.SetBool("IsRunning", false);
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
        Vector3 moveInput = _MoveInput.action.ReadValue<Vector2>();
        if (_isRunning)
        {
            //rb.velocity = moveInput * _vitesseSprint;
            //rb.AddForce(moveInput * _vitesseSprint);
            rb.MovePosition(transform.position + (moveInput * _vitesseSprint * Time.fixedDeltaTime));
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            //rb.AddForce(moveInput * _speed);
            rb.MovePosition(transform.position + (moveInput * _speed * Time.fixedDeltaTime));
            //rb.velocity = moveInput * _speed;
            _animator.SetBool("IsRunning", false);
        }
    }
}
   