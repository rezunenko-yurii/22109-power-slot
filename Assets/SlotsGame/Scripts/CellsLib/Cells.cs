using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.CellsLib
{
    public class Cells : MonoBehaviour
    {
        [Inject] private Config _config;
        [Inject] private Chips chips;
        [Inject] private Selectors selectors;

        private Cell[,] _cells;
        
        public void Init(Cell[,] cells)
        {
            _cells = cells;
            
            chips.Init(Chips());
            selectors.Init(Selectors());
        }
        
        private Chip[,] Chips()
        {
            var c = new Chip[_config.gridSize.x, _config.gridSize.y];
            
            for (var col = 0; col < _config.gridSize.y; col++)
            {
                for (var row = 0; row < _config.gridSize.x; row++)
                {
                    c[row, col] = _cells[row, col].chip;
                }
            }

            return c;
        }

        private Selector[,] Selectors()
        {
            var s = new Selector[_config.gridSize.x, _config.gridSize.y];
            
            for (var col = 0; col < _config.gridSize.y; col++)
            {
                for (var row = 0; row < _config.gridSize.x; row++) 
                {
                    s[row, col] = _cells[row, col].selector;
                }
            }

            return s;
        }

        public void Prepare()
        {
            chips.Prepare();
        }

        public void Appear()
        {
            chips.Appear();
        }

        public void ShowCombinations()
        {
            selectors.ShowCombinations();
        }

        public void HideCombinations()
        {
            selectors.HideCombinations();
        }
    }
}