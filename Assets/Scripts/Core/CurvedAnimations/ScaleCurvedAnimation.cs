using System;
using UnityEngine;

namespace Core.CurvedAnimations
{
    public class ScaleCurvedAnimation : BaseCurveAnimation
    {
        [SerializeField] private Transform target;
        
        public override event Action Started;
        public override event Action Ended;
        protected override void Animate()
        {
            //target.localScale = new Vector2(1 );
        }

        protected override void OnStarted()
        {
            throw new NotImplementedException();
        }

        protected override void OnEnded()
        {
            throw new NotImplementedException();
        }

        protected override void RemoveSubscribers()
        {
            throw new NotImplementedException();
        }
    }
}