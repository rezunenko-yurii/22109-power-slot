using TMPro;
using UnityEngine;

namespace Core.Steppers.TextPanels
{
    public abstract class TextStepper<T> : StepperView<T>
    {
        [SerializeField] protected TextMeshProUGUI textField;
    }
}