using System;
using System.Collections.Generic;
using GameCores.MemoryMatchGame;

namespace MemoryMatch.Scripts
{
    public class ProgressWatcher
    {
        public event Action Won;
        public event Action Lose;
        public event Action Match;
        public event Action Dissmatch;
        public event Action Continue;

        private Level _level;
        private int _sum;
        public int AttemptsLeft { get; private set; }
        
        public void Init(Level level)
        {
            _level = level;
            AttemptsLeft = _level.Attempts;
            CalculateLevelSum();
        }
        
        public void Handle(List<Element> selectedElements)
        {
            if (selectedElements.Count != 2)
            {
                Continue?.Invoke();
                return;
            }
            
            if (selectedElements[0].Id.Equals(selectedElements[1].Id))
            {
                OnMatched(selectedElements);
            }
            else
            {
                OnDissmatch(selectedElements);
            }
        }

        private void OnMatched(List<Element> obj)
        {
            CalculateHowMuchLeftForWin(obj);
            MarkAsMatched(obj);
            CheckWin();
        }

        private void MarkAsMatched(List<Element> obj)
        {
            foreach (var element in obj)
            {
                element.IsMatched = true;
            }
        }

        private void OnDissmatch(List<Element> obj)
        {
            CalculateHowMuchLeftForLose();
            CheckLose();
        }

        private void CalculateHowMuchLeftForLose()
        {
            AttemptsLeft--;
        }
        
        private void CalculateLevelSum()
        {
            _sum = 0;
            for (var i = 0; i < _level.Rows; i++)
            {
                for (var j = 0; j < _level.Cols; j++)
                {
                    _sum += _level.Field[i, j];
                }
            }
        }

        private void CalculateHowMuchLeftForWin(List<Element> obj)
        {
            foreach (var memoryMatchElement in obj)
            {
                _sum -= memoryMatchElement.Id;
            }
        }

        private void CheckWin()
        {
            if (_sum == 0)
            {
                Won?.Invoke();
            }
            else
            {
                Match?.Invoke();
            }
        }
        
        private void CheckLose()
        {
            if (AttemptsLeft == 0)
            {
                Lose?.Invoke();
            }
            else
            {
                Dissmatch?.Invoke();
            }
        }
    }
}