using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Elements_Combination : MonoBehaviour
{
    [SerializeField]
    private Button _fireButton;
    [SerializeField]
    private Button _waterButton;
    [SerializeField]
    private string _elementChosen;

    private string _elementCombination;
    private void Start()
    {
        _elementChosen = "Fire";
        _fireButton.onClick.AddListener(ChooseFire);
        _waterButton.onClick.AddListener(ChooseWater);
    }

    private void ChooseFire()
    {
        if(_elementChosen == "Water")
        {
            _elementChosen = "Fire+Water";
        }
        else
        {
            _elementChosen = "Fire";
        }
    }
    private void ChooseWater()
    {
        if (_elementChosen == "Fire")
        {
            _elementChosen = "Fire+Water";
        }
        else
        {
            _elementChosen = "Water";
        }
    }

    public string GetChosenElement()
    {
        return _elementChosen;
    }
}
