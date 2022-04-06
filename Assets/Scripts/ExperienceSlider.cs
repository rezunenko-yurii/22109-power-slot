using Core;
using LevelsModule;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ExperienceSlider : AdvancedMonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    [Inject] private ExperienceManager _experienceManager;
    [Inject] private Scores _scores;
    protected override void OnEnableInitialized()
    {
        base.OnEnableInitialized();
        ChangeSliderValue(_scores.Amount);
    }

    protected override void AddListeners()
    {
        base.AddListeners();
        _scores.Changed += ChangeSliderValue;
    }
    
    protected override void RemoveListeners()
    {
        base.RemoveListeners();
        _scores.Changed -= ChangeSliderValue;
    }
    
    private void ChangeSliderValue(int obj)
    {
        //Debug.Log($"{nameof(ExperienceSlider)} {nameof(ChangeSliderValue)} currentExp={obj}");

        int percent = HowManyPercentIsOneNumberFromAnother(obj, _experienceManager.GetTotalScoresForNewLevel);
        float normalized = NormalizeValue(percent, 0, 100);
        float sliderNewValue = SubtractPercentageFromTheNumber(50, percent);
        
        //Debug.Log($"{nameof(ExperienceSlider)} {nameof(ChangeSliderValue)} percent={percent} sliderNewValue={sliderNewValue}");
        
        _slider.value = sliderNewValue;

        if (sliderNewValue == 50)
        {
            _slider.value = 0;
        }
    }
    
    public float NormalizeValue(float currentValue, float lowerValue, float higherValue)
    {
        return (float) (((double) currentValue - (double) lowerValue) / ((double) higherValue - (double) lowerValue));
    }

    public int HowManyPercentIsOneNumberFromAnother(int number, int fromNumber)
    {
        float a = (float) number / fromNumber;
        int b = (int) (a * 100f);
        
        //Debug.Log($"{nameof(HowManyPercentIsOneNumberFromAnother)} number={number} fromNumber={fromNumber} a={a} b{b}");
        
        return b;
    }
    
    public float SubtractPercentageFromTheNumber(float fromNumber, int percent)
    {
        //Debug.Log($"{nameof(SubtractPercentageFromTheNumber)} fromNumber={fromNumber} percent={percent}");
        return fromNumber * ((float) percent / 100);
    }
}
