using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontUseEmailBtn : MonoBehaviour
{
    public void OnClick()
    {
        transform.GetParentComponent<ManageInput>().getDontUseMail();
    }
}
