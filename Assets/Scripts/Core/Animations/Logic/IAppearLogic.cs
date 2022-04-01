using Core.Animations.Alpha;

namespace Core.Animations
{
    public interface IAppearLogic
    {
        void Init();
        void AddAnimation(IAnimation animation);
        void Do();
    }
}