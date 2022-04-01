using System;
using Core;
using TMPro;
using UnityEngine;
using Zenject;

public class TimerMonoBehaviour : AdvancedMonoBehaviour
{
    public event Action Over;

    [Inject] private SignalBus signalBus;
    [SerializeField] private string _dividerSign = ":";
    
    public float timeRemaining = 120;
    public float frozenTime = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    private bool paused;

    public void StartCount()
    {
        timerIsRunning = true;
    }
    
    public void Stop()
    {
        timerIsRunning = false;
    }

    public void Reset(int levelTime)
    {
        timeRemaining = levelTime;
        frozenTime = 0;
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        
        //TODO FIX
        //signalBus.Subscribe<GameSignals.Pause>(OnPause);
        //signalBus.Subscribe<GameSignals.Resume>(OnResume);
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        
        //TODO FIX
        //signalBus.Unsubscribe<GameSignals.Pause>(OnPause);
        //signalBus.Unsubscribe<GameSignals.Resume>(OnResume);
    }

    private void OnResume()
    {
        paused = false;
    }

    private void OnPause()
    {
        paused = true;
    }

    private void Update()
    {
        if (timerIsRunning && !paused)
        {
            if (frozenTime > 0)
            {
                frozenTime -= Time.deltaTime;
            }
            else if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Over?.Invoke();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = $"{minutes:00}{_dividerSign}{seconds:00}";
    }
}