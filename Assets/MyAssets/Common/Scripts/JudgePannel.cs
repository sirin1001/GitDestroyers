using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JudgePannel : MonoBehaviour
{
    [SerializeField] private Image _judgeImage;
    [SerializeField] private Sprite _winSprite;
    [SerializeField] private Sprite _loseSprite;
    
    public void SetJudgeSprite(bool isWin)
    {
        if (isWin)
        {
            _judgeImage.sprite = _winSprite;
        }
        else
        {
            _judgeImage.sprite = _loseSprite;
        }
    }
}
