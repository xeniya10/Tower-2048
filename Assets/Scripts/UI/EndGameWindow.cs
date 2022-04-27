using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class EndGameWindow : MonoBehaviour
{
    public TextMeshProUGUI Result;
    public TextMeshProUGUI Score;
    public event Action OnClickCloseButtonEvent;

    public void Show(int finalScore)
    {
        this.gameObject.SetActive(true);
        SetFinalScore(finalScore);
    }
    public void OnClickCloseButton() => OnClickCloseButtonEvent?.Invoke();
    public void SetResult(bool isNewRecord)
    {
        if (isNewRecord)
        {
            Result.SetText("New record!\nCongratulations!");
        }
        else
        {
            Result.SetText("Nice game!\nYou are great!");
        }
    }
    private void SetFinalScore(int score)
    {
        Score.SetText($"{score}");
    }
}
