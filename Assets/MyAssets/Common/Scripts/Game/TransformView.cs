using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TransformView : MonoBehaviourPunCallbacks, IPunObservable
{
    private Vector3 _correctPlayerPos;
    private Vector3 _correctPlayerScale;

    private void Update(){
        if (photonView.IsMine)
        {
            _correctPlayerPos = transform.position;
            _correctPlayerScale = transform.localScale;
        }
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log("OnPhotonSerializeView");
        if (stream.IsWriting)
        {
            //データの送信
            stream.SendNext(_correctPlayerPos);
            stream.SendNext(_correctPlayerScale);
        }
        else
        {
            //データの受信
            _correctPlayerPos = (Vector3)stream.ReceiveNext();
            _correctPlayerScale = (Vector3)stream.ReceiveNext();
            transform.position = new Vector3(-_correctPlayerPos.x, _correctPlayerPos.y, _correctPlayerPos.z);
            transform.localScale = new Vector3(-_correctPlayerScale.x, _correctPlayerScale.y, _correctPlayerScale.z);
        }
    }
}
