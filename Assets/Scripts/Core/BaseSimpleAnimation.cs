using System;
using Core.Animations;
using UnityEngine;

namespace Core
{
    public abstract class BaseSimpleAnimation : AdvancedMonoBehaviour, ISimpleAnimation
    {
        public abstract event Action Played;
        
        public abstract void Play();
        public abstract void Stop();
    }
}