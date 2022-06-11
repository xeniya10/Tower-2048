using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
	public TextMeshProUGUI TimerText;

	private int _currentTime = 0;
	private int _secondsPerMinute = 60;

	public event Action TimeEndEvent;

	public void SetTimer(int targetMinuteDuration)
	{
		StartCoroutine(Time(targetMinuteDuration));
	}

	private IEnumerator Time(int targetMinuteDuration)
	{
		int targetSecondDuration = targetMinuteDuration * _secondsPerMinute;

		while (_currentTime < targetSecondDuration)
		{
			yield return new WaitForSeconds(1);

			int seconds = _secondsPerMinute - _currentTime % _secondsPerMinute;
			int minutes = targetMinuteDuration - (_currentTime + _secondsPerMinute) / _secondsPerMinute;

			if (seconds % _secondsPerMinute == 0)
			{
				seconds = 0;
				minutes++;
			}
			if (_currentTime == 0)
			{
				minutes = targetMinuteDuration;
			}

			_currentTime++;
			TimerText.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
		}

		TimeEndEvent?.Invoke();
	}

	public void ResetTimer(int targetMinuteDuration)
	{
		int seconds = 0;
		int minutes = targetMinuteDuration;
		_currentTime = 0;

		StopAllCoroutines();
		var timer = this.GetComponent<TextMeshProUGUI>();
		timer.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
	}
}
