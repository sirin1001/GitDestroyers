using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class Character : MonoBehaviour
{
    public enum CharacterState
    {
        Idle,
        Attack,
        Dead
    }
    [SerializeField] protected CharacterData _data;
    [SerializeField] protected Collider2D _collider;
    public CharacterState State { get; protected set; }
    public int Hp { get; set; }
    //スキルで値を変えるかもしれない
    public int _attack { get; protected set; }
    protected float _attackSpeed;
    protected int _skillCount;
    protected float _timeCount;
    protected const float AttackTime = 0.5f;
    // Start is called before the first frame update
    protected void Start()
    {
        _skillCount = 0;
        Hp = _data.MaxHp;
        _attack = _data.Attack;
        _attackSpeed = _data.AttackSpeed;
        _collider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _timeCount += Time.deltaTime;
        if (_timeCount >= _attackSpeed)
        {
            _timeCount = 0;
            StartCoroutine(Attack());
        }
    }
    protected virtual IEnumerator Attack()
    {
        State = CharacterState.Attack;
        _collider.gameObject.SetActive(true);
        yield return new WaitForSeconds(AttackTime);
        State = CharacterState.Idle;
        _collider.gameObject.SetActive(false);
    }
    public virtual void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            State = CharacterState.Dead;
        }
    }
    protected virtual void Skill()
    {
        
    }
}
