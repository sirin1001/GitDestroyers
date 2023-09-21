using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private CharacterAdmin _characterAdmin;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private GameObject _characterIconPrefab;

    private void Awake()
    {
        _characterAdmin = FindObjectOfType<CharacterAdmin>();
        if (_characterAdmin == null)
        {
            Debug.LogError("CharacterAdminが見つかりませんでした");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var character in _playerData.HaveCharacters)
        {
            var obj = Instantiate(_characterIconPrefab, Vector3.zero, Quaternion.identity, this.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.GetComponent<AddPartyCharacter>().SetCharacter(_characterAdmin.GetCharacterData(character));
        }
    }
}
