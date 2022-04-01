using Challenges;
using Conditions.Models;
using DefaultNamespace;
using Modules.Challenges.Scripts;
using UnityEngine;
using Zenject;

public class ConditionProgressSlider : AdvancedSlider
{
    [SerializeField] private ChallengeModel model;
    //[Inject] private ConditionsImp.Conditions _conditions;
    private Challenge _challenge;

    protected override void Initialize()
    {
        base.Initialize();
        //_challenge = _conditions.All[model];
    }

    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        //ChangeSliderValue(model.CurrentAmount, model.TargetAmount);
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        
        /*if (!model.IsFulfilled)
        {
            _challenge.ValueChanged += OnValueChanged;
        }*/
    }

    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        //_challenge.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        //ChangeSliderValue(model.CurrentAmount, model.TargetAmount);
    }
}
