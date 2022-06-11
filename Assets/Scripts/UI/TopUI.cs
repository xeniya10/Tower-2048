using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TopUI : MonoBehaviour
{
	public Score Score;
	public Timer Timer;

	public event Action OnClickMenuButtonEvent;

	public void OnClickMenuButton() => OnClickMenuButtonEvent?.Invoke();

	public void Show()
	{
		this.gameObject.SetActive(true);
	}
}
