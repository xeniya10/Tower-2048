using UnityEngine;
using System;
using TMPro;

public class EndGameWindow : MonoBehaviour
{
	public TextMeshProUGUI ResultText;
	public TextMeshProUGUI ScoreText;
	public event Action ClickCloseButtonEvent;

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void SetFinalScore(int score)
	{
		ScoreText.SetText($"{score}");
	}

	public void OnClickCloseButton() => ClickCloseButtonEvent?.Invoke();

	public void SetResult(bool isNewRecord)
	{
		switch (isNewRecord)
		{
			case true:
				ResultText.SetText("New record!\nCongratulations!");
				break;

			case false:
				ResultText.SetText("Nice game!\nYou are best!");
				break;
		}
	}


}
