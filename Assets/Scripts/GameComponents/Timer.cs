using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private int _currentTime = 0;
    private int _secondsPerMinute = 60;
    public event Action TimeEndEvent;
    public IEnumerator SetTimer(int targetMinuteDuration)
    {
        var timer = this.GetComponent<TextMeshProUGUI>();
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
            timer.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
        }

        TimeEndEvent?.Invoke();
    }

    public void ResetTimer()
    {
        int seconds = 0;
        int minutes = 3;
        _currentTime = 0;

        StopAllCoroutines();
        var timer = this.GetComponent<TextMeshProUGUI>();
        timer.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
