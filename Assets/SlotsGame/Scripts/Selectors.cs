using SlotsGame.Scripts.Combinations;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts
{
    public class Selectors : MonoBehaviour
    {
        [Inject] private CombinationHolder _combinationHolder;
        private Selector[,] _selectors;
        
        public void Init(Selector[,] selectors)
        {
            _selectors = selectors;
        }
        
        public void HideCombinations()
        {
            foreach (var selector in _selectors)
            {
                selector.Hide();
            }
        }
        
        public void ShowCombinations()
        {
            var winCells = _combinationHolder.GetWinCellsPositions();
            foreach (var pos in winCells)
            {
                _selectors[pos.x,pos.y].Show();
            }
        }
    }
}