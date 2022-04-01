using System;
using Core.CustomTimeline.Base;
using UnityEngine;

namespace Core.CustomTimeline.Implementations.Behaviours
{
    [Serializable]
    public class TransformRotationBehaviour : GenericPlayableBehaviour<Transform, Quaternion, float>
    {
        protected override void SetValue(Quaternion value)
        {
            Target.localRotation = value;
        }

        protected override Quaternion CalculateFinalValue(float progress, float progressedEase)
        {
            var value = Mathf.Lerp(StartValue, EndValue, progress) * progressedEase;
            Quaternion spinningRot = Quaternion.AngleAxis(value, Vector3.forward);
            return spinningRot;
        }
    }
}