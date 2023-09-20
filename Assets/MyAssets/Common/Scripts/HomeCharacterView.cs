using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeCharacterView : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    private SpriteRenderer _spriteRenderer;
    private CharacterAdmin _characterAdmin;

    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _characterAdmin = FindObjectOfType<CharacterAdmin>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = _characterAdmin.GetCharacterData(_playerData.PartyCharacters[0]).Icon ;
    }
}
