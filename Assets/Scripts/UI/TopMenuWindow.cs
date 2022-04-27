using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopMenuWindow : MonoBehaviour
{
    public event Action OnClickContinueButtonEvent;
    public event Action OnClickRestartButtonEvent;
    public event Action OnClickRecordsButtonEvent;
    public event Action OnClickQuitButtonEvent;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClickContinueButton() => OnClickContinueButtonEvent?.Invoke();
    public void OnClickRestartButton() => OnClickRestartButtonEvent?.Invoke();
    public void OnClickRecordsButton() => OnClickRecordsButtonEvent?.Invoke();
    public void OnClickQuitButton() => OnClickQuitButtonEvent?.Invoke();
}
