using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData", order = 0)]
public class PlayerData : ScriptableObject {
    public List<CharacterData> HaveCharacters = new List<CharacterData>();
    public CharacterData[] PartyCharacters = new CharacterData[4];
}