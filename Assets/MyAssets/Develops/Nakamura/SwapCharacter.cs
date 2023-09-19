using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SwapCharacter : MonoBehaviourPunCallbacks
{
    public Vector3[] _spawnPosition = new Vector3[4];
    private List<GameObject> CurrentParty = new List<GameObject>();
    
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
}
