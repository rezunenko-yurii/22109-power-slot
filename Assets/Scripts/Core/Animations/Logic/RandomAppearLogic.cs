namespace Core.Animations.Logic
{
    public class RandomAppearLogic : BaseAppearLogic
    {
        public override void Do()
        {
            var random = new System.Random();
            var step = 0.03f;
            var wholeDelay = 0f;
            
            while (Animations.Count > 0)
            {
                var num = random.Next(Animations.Count - 1);
                Animations[num].Play();
                wholeDelay += step;
                Animations.RemoveAt(num);
            }
        }
    }
}