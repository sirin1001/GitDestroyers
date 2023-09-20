using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using DG.Tweening;

public class TestResult : MonoBehaviourPunCallbacks
{
    [SerializeField] JudgePannel _judgePannel;
    private Character[] _characters;
    private List<Character> _playerCharacters;
    private List<Character> _enemyCharacters;
    private const float _waitTime = 1.0f;

    private void Start()
    {
        _judgePannel.gameObject.SetActive(false);
    }
    public void GetCharacterState()
    {
        DOVirtual.DelayedCall(_waitTime, () =>
        {
            _characters = FindObjectsOfType<Character>();
            _playerCharacters = new List<Character>();
            _enemyCharacters = new List<Character>();
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
        });
    }
    private void Update()
    {
        if (_playerCharacters == null || _enemyCharacters == null)
        {
            return;
        }
        if (IsPlayerWin())
        {
            _judgePannel.gameObject.SetActive(true);
            _judgePannel.SetJudgeText("Win");
        }
        else if (IsEnemyWin())
        {
            _judgePannel.gameObject.SetActive(true);
            _judgePannel.SetJudgeText("Lose");
        }
    }

    private bool IsPlayerWin()
    {
        foreach (var character in _enemyCharacters)
        {
            if (character.State != Character.CharacterState.Dead)
            {
                return false;
            }
        }
        return true;
    } 
    private bool IsEnemyWin()
    {
        foreach (var character in _playerCharacters)
        {
            if (character.State != Character.CharacterState.Dead)
            {
                return false;
            }
        }
        return true;
    }
}
