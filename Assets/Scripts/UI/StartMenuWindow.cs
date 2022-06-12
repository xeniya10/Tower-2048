using UnityEngine;
using System;

public class StartMenuWindow : MonoBehaviour
{
	public event Action ClickStartButtonEvent;
	public event Action ClickRecordsButtonEvent;
	public event Action ClickQuitButtonEvent;

	public void Show()
	{
		this.gameObject.SetActive(true);
	}
	public void OnClickStartButton() => ClickStartButtonEvent?.Invoke();
	public void OnClickRecordsButton() => ClickRecordsButtonEvent?.Invoke();
	public void OnClickQuitButton() => ClickQuitButtonEvent?.Invoke();
}
