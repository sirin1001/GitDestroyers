using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TestResult : MonoBehaviourPunCallbacks
{
    public Character[] _characters;
    public List<Character> _playerCharacters;
    public List<Character> _enemyCharacters;
    public bool _isPlayerWin;
    public bool _isEnemyWin;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Test", 10f);
    }

    private void Test()
    {
        _characters = FindObjectsOfType<Character>();
        foreach (var character in _characters)
        {
            if (character.photonView.IsMine)
            {
                _playerCharacters.Add(character);
            }
            else
            {
                _enemyCharacters.Add(character);
            }
        }
    }
    private void Update()
    {
        foreach (var character in _playerCharacters)
        {
            if (character.State != Character.CharacterState.Dead)
            {
                _isEnemyWin = false;
            }
        }
    }
}
