using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SwapCharacter : MonoBehaviourPunCallbacks
{
    [SerializeField] private TestPhoton _testPhoton;
    private List<GameObject> FieldCharacters = new List<GameObject>();
    public List<GameObject> CurrentParty = new List<GameObject>();
    
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
            CurrentParty[i].transform.position = _testPhoton._spawnPosition[i];
        }
    }
}
