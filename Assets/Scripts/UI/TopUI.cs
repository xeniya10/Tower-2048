using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TopUI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public delegate void TopMenuButton();
    public event TopMenuButton OnClickMenuButtonEvent;
    public void OnClickMenuButton() => OnClickMenuButtonEvent?.Invoke();
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public int ScoreNumber
    {
        get
        {
            int scoreNumber = Int32.Parse(Score.text);
            return scoreNumber;
        }
        set
        {
            int scoreNumber = value;
            Score.SetText($"{scoreNumber}");
        }
    }
}
