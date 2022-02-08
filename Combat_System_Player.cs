using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Combat_System_Player : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _inputMap;
    private Camera _camera;
    [SerializeField]
    private InputAction _castSpell;

    private Combat_Magic_Player_Component _magicComponent;

    // Start is called before the first frame update
    void Awake()
    {
        _castSpell = _inputMap.actions["MagicCast"];
        _magicComponent = gameObject.GetComponent<Combat_Magic_Player_Component>();
        _camera = Camera.main;
        
    }

    private void OnEnable()
    {
            _castSpell.performed += _ => _magicComponent.CastSpell(_camera);
    }

    private void OnDisable()
    {
        _castSpell.performed -= _ => _magicComponent.CastSpell(_camera);
    }

}
