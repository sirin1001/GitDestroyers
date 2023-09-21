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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
