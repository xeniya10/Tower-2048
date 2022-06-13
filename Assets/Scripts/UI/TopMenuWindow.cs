using UnityEngine;
using System;

public class TopMenuWindow : MonoBehaviour
{
	public event Action ClickContinueButtonEvent;
	public event Action ClickRestartButtonEvent;
	public event Action ClickQuitButtonEvent;

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void OnClickContinueButton() => ClickContinueButtonEvent?.Invoke();

	public void OnClickRestartButton() => ClickRestartButtonEvent?.Invoke();

	public void OnClickQuitButton() => ClickQuitButtonEvent?.Invoke();
}
