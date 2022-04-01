using System;
using UnityEngine;
using WheelLib;
using Debug = UnityEngine.Debug;

namespace DoubleGameLib
{
    public class DoubleGameWheelHelper : DoubleGameResult
    {
        [SerializeField] private Wheel _wheel;
        private Action _callback;

        protected override void OnEnableInitialized()
        {
            base.OnEnableInitialized();
            _wheel.Spun += OnSpun;
        }

        protected override void OnDisableInitialized()
        {
            base.OnDisableInitialized();
            _wheel.Spun -= OnSpun;
        }

        public override void SetNewType()
        {
            int sectorPosition = _wheel.GetSectorPosition();
            CardType = sectorPosition % 2 == 0 ? DoubleCardType.Blue : DoubleCardType.Red;
        }

        public override void Apply(Action callback)
        {
            _callback = callback;
            
            if (_wheel.Spinning)
            {
                Debug.Log($"{nameof(DoubleGameWheelHelper)} {nameof(Apply)} // Wheel already spinning");
                return;
            }
            
            _wheel.TrySpin();
        }

        private void OnSpun()
        {
            SetNewType();
            _callback.Invoke();
            _callback = null;
        }
    }
}