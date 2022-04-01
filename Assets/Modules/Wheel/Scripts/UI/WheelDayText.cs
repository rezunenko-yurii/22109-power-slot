using DailyReward;
using TMPro;
using UnityEngine;
using Zenject;

namespace WheelLib.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class WheelDayText : MonoBehaviour
    {
        private TextMeshProUGUI _textField;
        [Inject(Id = ModuleType.Wheel)] private EveryDayCounter _counter;

        private void Awake()
        {
            _textField = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            _textField.text = "Day " + (_counter.CurrentDay + 1);
        }
    }
}
