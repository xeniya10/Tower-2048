using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindow : MonoBehaviour
{
    public delegate void MenuButtons();
    public event MenuButtons OnClickStartButtonEvent;
    public event MenuButtons OnClickRecordsButtonEvent;
    public event MenuButtons OnClickQuitButtonEvent;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void OnClickStartButton() => OnClickStartButtonEvent?.Invoke();
    public void OnClickRecordsButton() => OnClickRecordsButtonEvent?.Invoke();
    public void OnClickQuitButton() => OnClickQuitButtonEvent?.Invoke();
}
