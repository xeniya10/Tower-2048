using System.Collections;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
	[HideInInspector] public int Seconds;
	[HideInInspector] public int Minutes;
	private int _currentSeconds = 0;
	private int _secondsPerMinute = 60;

	public event Action UpdateTimeEvent;
	public event Action TimeEndEvent;

	public void RunTimer(int targetMinuteDuration)
	{
		StartCoroutine(StartTimer(targetMinuteDuration));
	}

	private IEnumerator StartTimer(int targetMinuteDuration)
	{
		int targetSecondDuration = targetMinuteDuration * _secondsPerMinute;

		while (_currentSeconds < targetSecondDuration)
		{
			yield return new WaitForSeconds(1);

			Seconds = _secondsPerMinute - _currentSeconds % _secondsPerMinute;
			Minutes = targetMinuteDuration - (_currentSeconds + _secondsPerMinute) / _secondsPerMinute;

			if (Seconds == _secondsPerMinute)
			{
				Seconds = 0;
				Minutes++;
			}

			if (_currentSeconds == 0)
			{
				Minutes = targetMinuteDuration;
			}

			_currentSeconds++;
			UpdateTimeEvent?.Invoke();
		}
		TimeEndEvent?.Invoke();
	}

	public void ResetTimer(int targetMinuteDuration)
	{
		Seconds = 0;
		Minutes = targetMinuteDuration;
		_currentSeconds = 0;
		UpdateTimeEvent?.Invoke();

		StopAllCoroutines();
	}
}
