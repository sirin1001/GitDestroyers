using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject/PlayerData", order = 0)]
public class PlayerData : ScriptableObject {
    public List<int> HaveCharacters = new List<int>();
    public int[] PartyCharacters = new int[4];
}