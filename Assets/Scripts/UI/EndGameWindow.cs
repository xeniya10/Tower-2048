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

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void SetFinalScore(int score)
	{
		Score.SetText($"{score}");
	}

	public void OnClickCloseButton() => OnClickCloseButtonEvent?.Invoke();

	public void SetNewRecordText() => Result.SetText("New record!\nCongratulations!");

	public void SetNoRecordText() => Result.SetText("Nice game!\nYou are best!");


}
