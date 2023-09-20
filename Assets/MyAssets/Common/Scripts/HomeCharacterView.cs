using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HomeCharacterView : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private Image _image;
    private CharacterAdmin _characterAdmin;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _image = GetComponent<Image>();
        _characterAdmin = FindObjectOfType<CharacterAdmin>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sprite = _characterAdmin.GetCharacterData(_playerData.PartyCharacters[0]).Icon;
        }
        else if (_image != null)
        {
            _image.sprite = _characterAdmin.GetCharacterData(_playerData.PartyCharacters[0]).Icon;
        }
    }
}
