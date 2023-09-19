using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChara : MonoBehaviour
{
    public CharacterData status;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(status.CharacterName);
        Debug.Log(status.SkillName);
        Debug.Log(status.SkillDescription);
        Debug.Log(status.MaxHp);
        Debug.Log(status.Attack);
        Debug.Log(status.AttackSpeed);
        Debug.Log(status.AttackRange[0]);
        Debug.Log(status.AttackRange[1]);
        Debug.Log(status.AttackRange[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
