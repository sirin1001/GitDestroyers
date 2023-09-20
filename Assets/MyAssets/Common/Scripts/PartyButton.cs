using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyButton : MonoBehaviour
{
    private PartyEdit _partyEdit;
    private CharacterAdmin _characterAdmin;
    [SerializeField] private GameObject _characterList;
    [SerializeField] private int _index;
    [SerializeField] private Image _image;

    private void Awake() 
    {
        _partyEdit = FindObjectOfType<PartyEdit>();
        _characterAdmin = FindObjectOfType<CharacterAdmin>();
        if (_partyEdit == null)
        {
            Debug.LogError("PartyEditが見つかりませんでした");
        }
        if (_characterAdmin == null)
        {
            Debug.LogError("CharacterAdminが見つかりませんでした");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_partyEdit.TempPartyCharacters[_index] == 0)
        {
            _image.sprite = null;
            _image.color = new Color(0, 0, 0, 0);
        }
        else
        {
            _image.sprite = _characterAdmin.GetCharacterData(_partyEdit.TempPartyCharacters[_index]).Icon;
            _image.color = new Color(1, 1, 1, 1);
        }
    }
    public void PushButton()
    {
        _partyEdit.SetIndex(_index);
        Instantiate(_characterList, transform.parent.parent);
    }
}
