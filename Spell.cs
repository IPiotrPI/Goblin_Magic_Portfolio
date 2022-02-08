using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    [SerializeField]
    private GameObject _fire;
    [SerializeField]
    private GameObject _water;
    [SerializeField]
    private GameObject _fire_water;
    [SerializeField]
    private GameObject _currentElement;
    [SerializeField]
    private ChangeColor _swordElement;


    private void Start()
    {
        _currentElement = _fire;
    }

   
    public void ChangeElement(string Element)
    {
       if(Element == "Fire")
        {
            ChangeToFire();
            Element = "Current";
        }
       if(Element == "Water")
        {
            ChangeToWater();
            Element = "Current";
        }
       if(Element == "Fire+Water")
        {
            CombineFireWater();
            Element = "Current";
        }
    }
    private void ChangeToWater()
    {
        _currentElement = _water;
        _swordElement.Water();
    }

    private void ChangeToFire()
    {
        _currentElement = _fire;
        _swordElement.Fire();
    }

    private void CombineFireWater()
    {
        _currentElement = _fire_water;
        _swordElement.FireWater();
    }

    public GameObject CastSpell()
    {
        return _currentElement;
    }

}
