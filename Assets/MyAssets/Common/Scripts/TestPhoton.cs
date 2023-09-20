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
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            SpawnCharacter();
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            SpawnCharacter();
        }
    }
    private void SpawnCharacter(){
        for (int i = 0; i < _playerData.PartyCharacters.Length; i++)
        {
            if (_playerData.PartyCharacters[i] != null)
            {
                var obj = PhotonNetwork.Instantiate(_playerData.PartyCharacters[i].Prefab.name, _swapCharacter.SpawnPosition[i], Quaternion.identity);
                _swapCharacter.AddCurrentCharacters(obj);
            }
        }
    }
}
