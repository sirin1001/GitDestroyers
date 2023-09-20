using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitBtn : MonoBehaviour
{
    public void OnClick()
    {
        transform.GetParentComponent<ManageInput>().getSubmit();
    }
}
