using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterAdmin : MonoBehaviour
{
    [SerializeField] private List<CharacterData> _characterSource = new List<CharacterData>();
    
    public CharacterData GetCharacterData(int id)
    {
        return _characterSource.Find(c => c.CharacterID == id);
    }
}
