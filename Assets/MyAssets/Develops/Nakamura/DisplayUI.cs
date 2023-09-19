using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    public SwapCharacter _swapCharacter;
    [SerializeField] private int _index;
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Button _swapButton;
    private Character _character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_swapCharacter.CurrentParty.Count > _index)
        {
            _character = _swapCharacter.CurrentParty[_index].transform.GetChild(0).GetComponent<Character>();
            if (_character != null)
            {
                _hpSlider.maxValue = _character._data.MaxHp;
                _hpSlider.value = _character.Hp;
                _swapButton.image.sprite = _character._data.Icon;
                _swapButton.interactable = true;
            }
        }
        else
        {
            _hpSlider.value = 0;
            _swapButton.interactable = false;
        }
    }
}