using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class TestSlider : MonoBehaviour
{
    [SerializeField] private CharacterData _data;
    [SerializeField] private GameObject _gameObject;
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _data.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = _gameObject.GetComponent<Character>().Hp;
    }
}
