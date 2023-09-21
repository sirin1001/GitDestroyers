using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageAuthLog : MonoBehaviour
{
    string logMessage;
    
    public void setLogMessage(string authLog)
    {
        this.gameObject.GetComponent<TextMeshProUGUI>().text=authLog;
    }
}   
