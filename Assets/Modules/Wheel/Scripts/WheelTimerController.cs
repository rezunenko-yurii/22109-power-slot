using System;
using Core;
using Modules.Timers.Scripts;
using TMPro;
using UnityEngine;
using Zenject;

public class WheelTimerController : AdvancedMonoBehaviour
{
    [SerializeField] private GameObject backTimer;
    [SerializeField] private GameObject blackBack;
    [SerializeField] private TextMeshPro textMeshPro;

    [Inject] private Timers _timers;
    private MemoryTimer _timer;

    protected override void Initialize()
    {
        base.Initialize();
        _timer = (MemoryTimer) _timers.GetObject("timer.wheel");
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        if (!_timer.IsExpired)
        {
            SetNoClickable();
        }
    }

    protected override void AddListeners()
    {
        base.AddListeners();
            
        _timer.Over += SetClickable;
        _timer.Started += SetNoClickable;
        _timer.Counting += UpdateText;
    }

    private void SetNoClickable()
    {
        blackBack.SetActive(true);
        backTimer.SetActive(true);
        textMeshPro.gameObject.SetActive(true);
    }
    
    private void UpdateText(double seconds)
    {
        UpdateText(TimeSpan.FromSeconds(seconds));
    }

    private void UpdateText(TimeSpan obj)
    {
        textMeshPro.text = 
            $"{obj.Hours:00}:" +
            $"{obj.Minutes:00}:" +
            $"{obj.Seconds:00}";
    }

    private void SetClickable()
    {
        blackBack.SetActive(false);
        backTimer.SetActive(false);
        textMeshPro.gameObject.SetActive(false);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
            
        _timer.Over -= SetClickable;
        _timer.Started -= SetNoClickable;
        _timer.Counting -= UpdateText;
    }
}
