using UnityEngine;
using System;

public class TopMenuWindow : MonoBehaviour
{
	public event Action ClickContinueButtonEvent;
	public event Action ClickRestartButtonEvent;
	public event Action ClickQuitButtonEvent;

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void OnClickContinueButton() => ClickContinueButtonEvent?.Invoke();
	public void OnClickRestartButton() => ClickRestartButtonEvent?.Invoke();
	public void OnClickQuitButton() => ClickQuitButtonEvent?.Invoke();
}
