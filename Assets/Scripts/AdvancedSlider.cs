using Core;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedSlider : AdvancedMonoBehaviour
{
    [SerializeField] private Slider _slider;
        
    protected void ChangeSliderValue(int currentValue, int maxValue)
    {
        int percent = HowManyPercentIsOneNumberFromAnother(currentValue, maxValue);
        float sliderNewValue = SubtractPercentageFromTheNumber(100, percent);
            
        //Debug.Log($"{nameof(ExperienceSlider)} {nameof(ChangeSliderValue)} percent={percent} sliderNewValue={sliderNewValue}");
            
        _slider.value = sliderNewValue;
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