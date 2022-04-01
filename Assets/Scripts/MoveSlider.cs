using UnityEngine;
using UnityEngine.UI;

public class MoveSlider : Instruction
{
    private Slider _slider;
    private int _time;

    private float _from = 0f;
    private float _to = 50f;
    
    private float _t = 0f;
    
    public MoveSlider(MonoBehaviour parent, Slider slider, int time) : base(parent)
    {
        _slider = slider;
        _time = time;
        
        Debug.Log($"Started Time {Time.time}");
    }

    protected override bool Update()
    {
        _t += Time.deltaTime / _time;
        _slider.value = Mathf.Lerp(_from, _to, _t);
        
        return _slider.value < _to;
    }
}