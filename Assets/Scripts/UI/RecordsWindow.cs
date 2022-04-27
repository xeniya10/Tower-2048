using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RecordsWindow : MonoBehaviour
{
    public event Action OnClickCloseButtonEvent;

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void OnClickCloseButton() => OnClickCloseButtonEvent?.Invoke();
}
