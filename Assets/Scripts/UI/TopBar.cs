using UnityEngine;
using System;
using TMPro;

public class TopBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    public event Action ClickMenuButtonEvent;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void SetScore() => _scoreText.SetText($"{Score.Number}");

    public void SetTime(int minutes, int seconds)
    {
        _timerText.SetText(String.Format("{0:00}:{1:00}", minutes, seconds));
    }

    public void OnClickMenuButton() => ClickMenuButtonEvent?.Invoke();
}
