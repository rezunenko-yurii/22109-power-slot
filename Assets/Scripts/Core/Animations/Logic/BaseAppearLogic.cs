using System.Collections.Generic;
using Core.Animations.Alpha;
using UnityEngine;

namespace Core.Animations
{
    public abstract class BaseAppearLogic : MonoBehaviour, IAppearLogic
    {
        protected List<IAnimation> Animations;

        public void Init()
        {
            Animations = new List<IAnimation>();
        }

        public void AddAnimation(IAnimation animation)
        {
            if (!Animations.Contains(animation))
            {
                Animations.Add(animation);
            }
            else
            {
                Debug.LogWarning("Animation already contains in list");
            }
        }

        public abstract void Do();
    }
}