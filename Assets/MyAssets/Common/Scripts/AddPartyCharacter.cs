using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPartyCharacter : MonoBehaviour
{
    [SerializeField] private Image _image;
    private int _id;
    public void SetCharacter(CharacterData characterData)
    {
        _id = characterData.CharacterID;
        _image.sprite = characterData.Icon;
    }
    public void PushButton()
    {
        var partyEdit = FindObjectOfType<PartyEdit>();
        partyEdit.AddPartyCharacter(_id);
        Destroy(transform.parent.parent.parent.parent.gameObject);
    }
}
