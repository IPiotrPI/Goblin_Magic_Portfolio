using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTransform;
    private PlayerDashComponent _dash;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float _rotationSpeed;

    private CharacterController _controller;
    private Vector3 _velocity;
    private PlayerInput _inputMap;
    private InputAction _moveAction;
    private InputAction _dashAction;
    private IPlayer_Animation_Component _anim;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _controller = GetComponent<CharacterController>();
        _inputMap = GetComponent<PlayerInput>();
        _dash = GetComponent<PlayerDashComponent>();
        _anim = GetComponent<Player_Animation_Component>();
        _cameraTransform = Camera.main.transform;
        _moveAction = _inputMap.actions["Move"];
        _dashAction = _inputMap.actions["Dash"];
    }

   
    private Vector3 MovementSystem()
    {
      
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * _cameraTransform.right.normalized + move.z * _cameraTransform.forward.normalized;
        move.y = 0f;
        _controller.Move(move * playerSpeed * Time.deltaTime);
        _anim.MovementAnimationSystem(input);
        if (_dashAction.triggered)
        {
            if (move != Vector3.zero)
            {
                StartCoroutine(_dash.Dash(move, _controller));
            }
            else
            {
                Vector3 moveForward = new Vector3(0, 0, 1);
                StartCoroutine(_dash.Dash(moveForward, _controller));
            }
        }
        
        return move;      
    }

    private void MouseRotation()
    {
        Quaternion _rotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
    }

    /*private void MovementSystem()
    {
        Vector2 input = _moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        _controller.Move(move * playerSpeed * Time.deltaTime);
       
        gameObject.transform.forward = Velocity();
    }*/

    // Update is called once per frame
    void Update()
    {
        MouseRotation();
        MovementSystem();
        Debug.Log(transform.rotation);
    }
}
