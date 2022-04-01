using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Core.CustomTimeline.Base
{
	[Serializable]
    public class BasePlayableBehaviour : PlayableBehaviour
    {
	    [field: SerializeField] public AnimationCurve Ease { get; private set; }
    }
}