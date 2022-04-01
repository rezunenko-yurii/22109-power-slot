using System;

namespace LevelsModule
{
    public interface IScores
    {
        public event Action<int> Added;
        public event Action<int> Changed;
        
        public int Amount { get; }
        public void Add(int newAmount);
        public void Reset();
    }
}