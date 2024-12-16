using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button _button;
    
    public void Bind(Action onClickCallback)
    {
        _button.onClick.AddListener(onClickCallback.Invoke);
    }
}
