using UnityEngine;
using System;

public class StartMenuWindow : MonoBehaviour
{
    public event Action ClickStartButtonEvent;
    public event Action ClickRecordsButtonEvent;
    public event Action ClickQuitButtonEvent;

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    public void OnClickStartButton() => ClickStartButtonEvent?.Invoke();

    public void OnClickRecordsButton() => ClickRecordsButtonEvent?.Invoke();

    public void OnClickQuitButton() => ClickQuitButtonEvent?.Invoke();
}
