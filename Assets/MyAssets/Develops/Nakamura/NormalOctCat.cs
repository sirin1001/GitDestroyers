using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalOctCat : Character
{
    [SerializeField] private float _skillTime;
    private float _skillTimeCount;
    protected override void Update()
    {
        _skillTimeCount += Time.deltaTime;
        if (_skillTimeCount >= _skillTime)
        {
            _skillTimeCount = 0;
            EndSkill();
        }
        base.Update();
    }
    protected override void Skill()
    {
        Debug.Log("NormalOctCat Skill");
        _attack *= 2;
        _skillTimeCount = 0;
    }
    protected override void EndSkill()
    {
        Debug.Log("NormalOctCat EndSkill");
        _attack = _data.Attack;
    }
}
