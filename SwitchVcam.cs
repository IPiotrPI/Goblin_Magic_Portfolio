using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine;

public class SwitchVcam : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _inputMap;
    [SerializeField]
    private int _cameraPriorityChange;
    [SerializeField]
    private Canvas _thirdPersonCanvas;
    [SerializeField]
    private Canvas _aimCanvas;

    private bool _amIAiming;
    private CinemachineVirtualCamera _virtualCamera;
    private InputAction _aimAction;
    



    private void Awake()
    {
        _aimCanvas.enabled = false;
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        _aimAction = _inputMap.actions["Magic"];
    }

    private void OnEnable()
    {
        _aimAction.performed += _ => StartAim();

        _aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable()
    {
        _aimAction.performed -= _ => StartAim();

        _aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        _amIAiming = true;
        _virtualCamera.Priority += _cameraPriorityChange;       
        _aimCanvas.enabled = true;
        _thirdPersonCanvas.enabled = false;
    }

    private void CancelAim()
    {
        _amIAiming = false;
        _virtualCamera.Priority -= _cameraPriorityChange;
        _aimCanvas.enabled = false;
        _thirdPersonCanvas.enabled = true;
    }

    public  bool GetAmIAiming()
    {
        return _amIAiming;
    }
}
