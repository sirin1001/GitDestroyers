using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RandomBackground : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] private Sprite[] _backgrounds;
    private SpriteRenderer _spriteRenderer;
    private int _random;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _random = Random.Range(0, _backgrounds.Length);
            _spriteRenderer.sprite = _backgrounds[_random];
        }
    }
    
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_random);
        }
        else
        {
            _random = (int)stream.ReceiveNext();
            _spriteRenderer.sprite = _backgrounds[_random];
        }
    }
}
