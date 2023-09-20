using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyEdit : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GameObject _errorText;
    public int[] TempPartyCharacters { get; private set; } = new int[4];
    private int _tempPartyCharactersIndex = 0;

    private void Awake()
    {
        TempPartyCharacters = _playerData.PartyCharacters.Clone() as int[];
        _errorText.SetActive(false);
    }
    public void SetIndex(int index)
    {
        _tempPartyCharactersIndex = index;
    }
    public void AddPartyCharacter(int id)
    {
        if (TempPartyCharacters[_tempPartyCharactersIndex] == id)
        {
            TempPartyCharacters[_tempPartyCharactersIndex] = 0;
        }
        else if (_tempPartyCharactersIndex < TempPartyCharacters.Length)
        {
            TempPartyCharacters[_tempPartyCharactersIndex] = id;
        }
    }
    public void SaveParty()
    {
        var isPossible = true;
        foreach (var character in TempPartyCharacters)
        {
            if (character == 0)
            {
                _errorText.SetActive(true);
                isPossible = false;
            }
        }
        if (isPossible)
        {
            _playerData.PartyCharacters = TempPartyCharacters.Clone() as int[];
        }
    }

    public void Buttton()
    {
        _errorText.SetActive(false);
    }
}
