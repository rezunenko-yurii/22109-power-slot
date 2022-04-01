using UnityEngine;
using UnityEngine.Playables;

namespace Core.CustomTimeline.Base
{
    public abstract class GenericPlayableBehaviour<TTarget, TValue, TConfigValue> : BasePlayableBehaviour where TTarget : class
    {
        protected TTarget Target;
        [field: SerializeField] protected TConfigValue StartValue { get; private set; }
        [field: SerializeField] protected TConfigValue EndValue { get; private set; }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);
            
            Target = playerData as TTarget;
            
            float progress = (float)(playable.GetTime() / playable.GetDuration());
            var progressedEase = Ease.Evaluate(progress);
            
            TValue v = CalculateFinalValue(progress, progressedEase);
		    SetValue(v);
        }

        protected abstract void SetValue(TValue value);

        protected abstract TValue CalculateFinalValue(float progress, float progressedEase);
    }
}