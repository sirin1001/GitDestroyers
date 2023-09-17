using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Character _character;
    private Character _target;
    protected void OnTriggerEnter2D(Collider2D other) {
        _target = other.gameObject.GetComponent<Character>();
        if (_target != null)
        {
            Debug.Log("Hit");
            _target.Damage(_character._attack);
        }
    }
}
