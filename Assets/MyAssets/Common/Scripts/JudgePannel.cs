using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JudgePannel : MonoBehaviour
{
    [SerializeField] private TMP_Text _judgeText;
    
    public void SetJudgeText(string text)
    {
        _judgeText.text = text;
    }
}
