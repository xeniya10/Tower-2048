using UnityEngine;
using System;

public class TopUI : MonoBehaviour
{
	public Score Score;
	// public Timer Timer;

	public event Action ClickMenuButtonEvent;

	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void OnClickMenuButton() => ClickMenuButtonEvent?.Invoke();
}
