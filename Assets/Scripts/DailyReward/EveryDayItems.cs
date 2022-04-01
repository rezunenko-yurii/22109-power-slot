using Modules.Dates;
using UnityEngine;
using WheelLib.Days;
using Zenject;

namespace DailyReward
{
    public class EveryDayItems : MonoBehaviour
    {
        [Inject(Id = ModuleType.Wheel)] private EveryDayCounter _counter;
        [Inject(Id = ModuleType.Wheel)] private LastDateKeeper _dateKeeper;

        [field: SerializeReference, SerializeReferenceButton] private IDays days;

        private void Start()
        {
            UpdateCurrentDay();
        }

        private void UpdateCurrentDay()
        {
            days.UpdateCurrentDay(_counter.CurrentDay);
        }

        private void OnEnable()
        {
            _dateKeeper.Updated += UpdateCurrentDay;
        }

        private void OnDisable()
        {
            _dateKeeper.Updated -= UpdateCurrentDay;
        }
    }
}