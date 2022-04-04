using Modules.Challenges.Scripts;
using UnityEngine;
using Zenject;

public class ChallengeProgressSlider : AdvancedSlider
{
    [Inject] private Challenges _challenges;
    [SerializeField] private string _challengeId;
    private Challenge _challenge;
    
    protected override void Initialize()
    {
        base.Initialize();
        _challenge = _challenges.GetObject(_challengeId);
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        ChangeSliderValue(_challenge.Task.CurrentAmount, _challenge.Task.TargetAmount);
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        
        _challenge.Task.ValueChanged += OnValueChanged;
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        _challenge.Task.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        ChangeSliderValue(_challenge.Task.CurrentAmount, _challenge.Task.TargetAmount);
    }
}
