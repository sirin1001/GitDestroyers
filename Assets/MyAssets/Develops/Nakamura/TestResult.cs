using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TestResult : MonoBehaviourPunCallbacks
{
    public Character[] _characters;
     List<Character> _playerCharacters;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(10);
        _characters = FindObjectsOfType<Character>();
        foreach (var character in _characters)
        {
            if (character.GetComponent<PhotonView>().IsMine)
            {
                _playerCharacters.Add(character);
            }
        }
    }
}
