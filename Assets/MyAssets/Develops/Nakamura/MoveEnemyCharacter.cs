using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MoveEnemyCharacter : MonoBehaviourPunCallbacks
{
    public void Move(){
        if (photonView.IsMine)
        {
            Debug.Log("Move");
            transform.position.Set(transform.position.x * -1, transform.position.y, transform.position.z);
            transform.localScale.Set(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
