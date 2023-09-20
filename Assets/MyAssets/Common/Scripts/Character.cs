using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Character))]
public abstract class Character : MonoBehaviourPunCallbacks, IPunObservable
{
    public enum CharacterState
    {
        Idle,
        Dead
    }
    [field : SerializeField] public CharacterData _data { get; private set;}
    [SerializeField] protected Collider2D _collider;
    public CharacterState State { get; protected set; }
    public int Hp { get; set; }
    //スキルで値を変えるかもしれない
    public int AttackPower { get; set; }
    protected float _attackSpeed;
    protected float _timeCount;
    protected const float AttackTime = 0.5f;
    protected float _attackTime;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        State = CharacterState.Idle;
        AttackPower = _data.Attack;
        _attackSpeed = _data.AttackSpeed;
        Hp = _data.MaxHp;
        _attackTime = AttackTime;
        _collider.gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected void Update()
    {
        _timeCount += Time.deltaTime;
        if (_timeCount >= _attackSpeed && State == CharacterState.Idle)
        {
            _timeCount = 0;
            Attack();
        }
    }
    protected virtual void Attack()
    {
        _collider.gameObject.SetActive(true);
        DOVirtual.DelayedCall(_attackTime, () => _collider.gameObject.SetActive(false));
    }

    public virtual void Damage(int damage)
    {
        if (photonView.IsMine){
            Hp -= damage;
            if (Hp <= 0)
            {
                EndSkill();
                State = CharacterState.Dead;
            }
        }
    }
    protected virtual void Skill()
    {
        
    }
    protected virtual void EndSkill()
    {
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(Hp);
            stream.SendNext(State);
        }
        else
        {
            //データの受信
            Hp = (int)stream.ReceiveNext();
            State = (CharacterState)stream.ReceiveNext();
        }
    }
}
