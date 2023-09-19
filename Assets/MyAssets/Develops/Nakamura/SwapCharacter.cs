using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SwapCharacter : MonoBehaviourPunCallbacks
{
    public Vector3[] _spawnPosition = new Vector3[4];
    public List<GameObject> CurrentParty { get; private set; } = new List<GameObject>();
    private const int DefaultIndex = 10;
    private int _selectIndex1;
    private int _selectIndex2;
    
    private void Start(){
        _selectIndex1 = DefaultIndex;
        _selectIndex2 = DefaultIndex;
    }
    public void AddCurrentCharacters(GameObject obj)
    {
        if (CurrentParty.Count > 4)
        {
            return;
        }
        if (obj.GetComponent<PhotonView>().IsMine)
        {
            CurrentParty.Add(obj);
        }
    }

    private void Update(){
        for (int i = 0; i < CurrentParty.Count; i++)
        {
            if (CurrentParty[i] == null)
            {
                CurrentParty.RemoveAt(i);
            }
            CurrentParty[i].transform.position = _spawnPosition[i];
        }
    }

    public void SwapSelect(int index)
    {
        if (_selectIndex1 == DefaultIndex)
        {
            _selectIndex1 = index;
        }
        else if (_selectIndex2 == DefaultIndex)
        {
            _selectIndex2 = index;
            Swap(_selectIndex1, _selectIndex2);
            _selectIndex1 = DefaultIndex;
            _selectIndex2 = DefaultIndex;
        }
    }
    private void Swap(int index1, int index2)
    {
        if (index1 == DefaultIndex || index2 == DefaultIndex)
        {
            return;
        }
        var obj = CurrentParty[index1];
        CurrentParty[index1] = CurrentParty[index2];
        CurrentParty[index2] = obj;
    }
}
