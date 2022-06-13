using UnityEngine;
using System;
using TMPro;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    public event Action ClickCloseButtonEvent;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void SetFinalScore(int score) => _scoreText.SetText($"{score}");

    public void SetResult(bool isNewRecord)
    {
        if (isNewRecord)
            _resultText.SetText("New record!\nCongratulations!");
        else _resultText.SetText("Nice game!\nYou are best!");
    }

    public void OnClickCloseButton() => ClickCloseButtonEvent?.Invoke();
}
