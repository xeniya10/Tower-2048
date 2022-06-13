using System;
using UnityEngine;

public class RecordWindow : MonoBehaviour
{
	public event Action ClickCloseButtonEvent;

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		gameObject.SetActive(false);
	}

	public void OnClickCloseButton() => ClickCloseButtonEvent?.Invoke();
}
