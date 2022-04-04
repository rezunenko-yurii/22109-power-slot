using System;
using Core;
using Modules.Timers.Scripts;
using TMPro;
using UnityEngine;
using WheelLib;

public abstract class TimerText : AdvancedMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textfield;
    [SerializeField] private string readyText;
    [SerializeField] private WheelTimerOver _wheelTimerOver;

    protected abstract MemoryTimer Timer { get; }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        if (Timer.IsExpired)
        {
            _textfield.text = readyText;
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        
        Timer.Counting += SetTimerText;
        Timer.Over += OnOver;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        
        Timer.Counting -= SetTimerText;
        Timer.Over -= OnOver;
    }
    
    private void OnOver()
    {
        if (_wheelTimerOver == WheelTimerOver.Hide)
        {
            ChangeStateOfChildren(false);
        }
        else
        {
            _textfield.text = readyText;
        }
    }
        
    private void ChangeStateOfChildren(bool isEnable)
    {
        Debug.Log($"ChangeStateOfChildren {isEnable}");
        
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isEnable);
        }
    }
    
    private void SetTimerText(int seconds)
    {
        SetTimerText(TimeSpan.FromSeconds(seconds));
    }
        
    private void SetTimerText(TimeSpan timeSpan)
    {
        _textfield.text = $"{timeSpan.Hours:00}:" +
                          $"{timeSpan.Minutes:00}:" +
                          $"{timeSpan.Seconds:00}";
    }
}