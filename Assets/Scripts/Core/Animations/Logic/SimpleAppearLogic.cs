using System;

namespace Core.Animations
{
    public class SimpleAppearLogic : BaseAppearLogic
    {
        public override void Do()
        {
            foreach (var appearAnimation in Animations)
            {
                appearAnimation.Play();
            }
        }
    }
}