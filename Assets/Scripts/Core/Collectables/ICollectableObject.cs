namespace Core.Collectables
{
    public interface ICollectableObject<T>
    {
        T Amount { get;}
        T Remainder(T value);
        bool IsRemainderPositive(T value);
        void Increase();
        void Increase(T amount);
        void Decrease();
        void Decrease(T amount);
        void Reset();
    }
}