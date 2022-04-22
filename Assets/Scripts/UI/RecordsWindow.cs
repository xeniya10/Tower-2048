using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RecordsWindow : MonoBehaviour
{
    public delegate void CloseButton();
    public event CloseButton OnClickCloseButtonEvent;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void OnClickCloseButton() => OnClickCloseButtonEvent?.Invoke();
}
