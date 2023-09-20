using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalOctCat : Character
{
    [SerializeField] private float _skillTime;
    [SerializeField] private float _skillCount;
    [SerializeField] private GameObject _skillEffect;
    private float _count;

    protected override void Start()
    {
        base.Start();
        _count = 0;
        _skillEffect.SetActive(false);
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
        _skillEffect.SetActive(true);
        AttackPower *= 2;
        Invoke(nameof(EndSkill), _skillTime);
    }
    protected override void EndSkill()
    {
        Debug.Log("NormalOctCat EndSkill");
        _skillEffect.SetActive(false);
        AttackPower = _data.Attack;
    }
}
