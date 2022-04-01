using DefaultNamespace;
using UnityEngine;

namespace DailyBonusModule.States
{
    public class DailyBonusEmptyState : DailyBonusState
    {
        [SerializeField] private Sprite sprite;
        protected override DailyBonusStates State { get; }
        public override void Apply()
        {
            Context.Skin.sprite = sprite;
        }

        public override void BeforeChanged()
        {
            //throw new System.NotImplementedException();
        }

        public override bool CanApply(int itemDay, int currentDay, int passedDay)
        {
            return currentDay > itemDay;
        }
    }
}