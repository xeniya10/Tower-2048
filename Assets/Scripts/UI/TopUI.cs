using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TopUI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public Timer Timer;
    public event Action OnClickMenuButtonEvent;
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
    public void SetTimerTime(int targetMinuteDuration)
    {
        StartCoroutine(Timer.SetTimer(targetMinuteDuration));
    }

    public void ResetTimerTime()
    {
        Timer.ResetTimer();
    }
}
