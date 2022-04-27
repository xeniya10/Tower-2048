using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartMenuWindow : MonoBehaviour
{
    public event Action OnClickStartButtonEvent;
    public event Action OnClickRecordsButtonEvent;
    public event Action OnClickQuitButtonEvent;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void OnClickStartButton() => OnClickStartButtonEvent?.Invoke();
    public void OnClickRecordsButton() => OnClickRecordsButtonEvent?.Invoke();
    public void OnClickQuitButton() => OnClickQuitButtonEvent?.Invoke();
}
