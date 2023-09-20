using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Attack : MonoBehaviourPunCallbacks
{
    [SerializeField] private Character _character;
    private Character _target;
    protected void OnTriggerEnter2D(Collider2D other) {
        _target = other.gameObject.GetComponent<Character>();
        if (_target != null)
        {
            _target.Damage(_character.AttackPower);
        }
    }
}
