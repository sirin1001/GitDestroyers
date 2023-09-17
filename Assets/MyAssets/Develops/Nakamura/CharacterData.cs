using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/New CharacterData", order = 0)]
public class CharacterData : ScriptableObject {
    public int CharacterID;
    public string CharacterName;
    public string SkillName;
    public string SkillDescription;
    public int MaxHp;
    public int Attack;
    public float AttackSpeed;
    public bool[] AttackRange = new bool[3];
    public GameObject Prefab;
    public Sprite Icon;
}