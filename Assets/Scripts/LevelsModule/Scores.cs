using System;
using Core.Collectables;

namespace LevelsModule
{
    public class Scores : IScores
    {
        public event Action<int> Added;
        public event Action<int> Changed;

        private readonly IntCollectableObject _current = new IntCollectableObject("Scores", 0);
        public int Amount => _current.Amount;

        public void Add(int newAmount)
        {
            _current.Amount += newAmount;
            Added?.Invoke(newAmount);
            Changed?.Invoke(_current.Amount);
        }

        public void Reset()
        {
            _current.Reset();
            Changed?.Invoke(_current.Amount);
        }
    }
}