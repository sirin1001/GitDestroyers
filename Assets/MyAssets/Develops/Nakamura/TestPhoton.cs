using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class TestPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private SwapCharacter _swapCharacter;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        for (int i = 0; i < _playerData.PartyCharacters.Length; i++)
        {
            if (_playerData.PartyCharacters[i] != null)
            {
                var obj = PhotonNetwork.Instantiate(_playerData.PartyCharacters[i].Prefab.name, _swapCharacter._spawnPosition[i], Quaternion.identity);
                _swapCharacter.AddCurrentCharacters(obj);
            }
        }
    }
}
