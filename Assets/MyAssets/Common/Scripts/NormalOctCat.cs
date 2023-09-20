using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalOctCat : Character
{
    [SerializeField] private float _skillTime;
    [SerializeField] private float _skillCount;
    private float _count;

    protected override void Start()
    {
        base.Start();
        _count = 0;
    }
    protected override void Attack(){
        _count += 1;
        if (_count >= _skillCount)
        {
            _count = 0;
            Skill();
        }
        base.Attack();
    }
    protected override void Skill()
    {
        Debug.Log("NormalOctCat Skill");
        AttackPower *= 2;
        Invoke(nameof(EndSkill), _skillTime);
    }
    protected override void EndSkill()
    {
        Debug.Log("NormalOctCat EndSkill");
        AttackPower = _data.Attack;
    }
}
