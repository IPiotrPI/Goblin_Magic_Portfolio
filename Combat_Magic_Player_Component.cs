using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Magic_Player_Component : MonoBehaviour
{
    [SerializeField]
    private Transform _castTransform;
    [SerializeField]
    private Transform _spellParent;
    [SerializeField]
    private GameObject _firePrefab;
    [SerializeField]
    private GameObject _waterPrefab;
    [SerializeField]
    private float spread;
    [SerializeField]
    private float range;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera _aimCamera;
    private Spell _cast;

    public GameObject _lastHit;
    private LineRenderer laserLine;

    private void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        _cast = GetComponent<Spell>();
    }
    public void CastSpell(Camera _camera)
    {
        if(_aimCamera.m_Priority > 10)
        {
            Vector3 _reyOrigin = _camera.ViewportToWorldPoint(_castTransform.position);
            RaycastHit hit;
            laserLine.SetPosition(0, _castTransform.position);
            GameObject _fire = GameObject.Instantiate(_cast.CastSpell(), _castTransform.position, Quaternion.identity, _spellParent);
            FireController _fireController = _fire.GetComponent<FireController>();
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit))
            {
                _lastHit = hit.transform.gameObject;
                laserLine.SetPosition(1, hit.point);
                _fireController.target = hit.point;
                _fireController.hit = true;
            }
            else
            {
                laserLine.SetPosition(1, _reyOrigin + (_camera.transform.forward * range));
                _fireController.target = _camera.transform.position + (_camera.transform.forward * (range));
                _fireController.hit = false;
            }
        }
        else
        {
            Debug.Log("Wrong Camera");
        }
     
    }
}
