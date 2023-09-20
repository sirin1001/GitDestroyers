using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

[RequireComponent(typeof(TestResult), typeof(SwapCharacter))]
public class TestPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField] private PlayerData _playerData;
    private CharacterAdmin _characterAdmin;
    private SwapCharacter _swapCharacter;
    private TestResult _testResult;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        _characterAdmin = FindObjectOfType<CharacterAdmin>();
        _swapCharacter = GetComponent<SwapCharacter>();
        _testResult = GetComponent<TestResult>();
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
            var _party = _characterAdmin.GetCharacterData(_playerData.PartyCharacters[i]);
            if (_party != null)
            {
                var obj = PhotonNetwork.Instantiate(_party.Prefab.name, _swapCharacter.SpawnPosition[i], Quaternion.identity);
                _swapCharacter.AddCurrentCharacters(obj);
            }
        }
        _testResult.GetCharacterState();
    }
}
