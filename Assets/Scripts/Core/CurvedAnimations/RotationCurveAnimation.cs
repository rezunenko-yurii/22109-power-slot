using System;
using UnityEngine;

namespace Core.CurvedAnimations
{
    public class RotationCurveAnimation : BaseCurveAnimation
    {
        [SerializeField] private Transform target;

        public override event Action Started;
        public override event Action Ended;

        protected override void Animate()
        {
            Debug.Log(Value);
            target.Rotate(0, 0, Value);
        }

        protected override void OnStarted()
        {
            Started?.Invoke();
        }

        protected override void OnEnded()
        {
            Ended?.Invoke();
        }

        protected override void RemoveSubscribers()
        {
            Started = null;
            Ended = null;
        }
    }
}
