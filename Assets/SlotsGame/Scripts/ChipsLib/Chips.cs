using Core.Animations;
using SlotsGame.Scripts.Combinations;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.ChipsLib
{
    public class Chips : MonoBehaviour
    {
        [SerializeField] private BaseAppearLogic chipsAppearLogic;

        [Inject] private Config _config;
        [Inject]private CombinationHolder _combinationHolder;

        private Chip[,] _chips;

        public void Init(Chip[,] chips)
        {
            _chips = chips;
            AddFakes();
            
            InitChipsAppearLogic();
        }
        
        private void AddFakes()
        {
            for (int col = 0; col < _config.gridSize.y; col++)
            {
                for (int row = 0; row < _config.gridSize.x; row++)
                {
                    _chips[row, col].AddToStack(_combinationHolder.GetRandom());
                    _chips[row, col].SetNext();
                }
            }
        }
        
        public void Prepare()
        {
            FillStack();
        }

        private void FillStack()
        {
            for (int col = 0; col < _config.gridSize.y; col++)
            {
                for (int row = 0; row < _config.gridSize.x; row++)
                {
                    var chip = _chips[row, col];
                    chip.AddToStack(_combinationHolder.grid[row, col]);

                    while (!chip._changer.IsStackFool)
                    {
                        chip.AddToStack(_combinationHolder.GetRandom());
                    }
                }
            }
        }
        
        private void InitChipsAppearLogic()
        {
            chipsAppearLogic.Init();
            foreach (var chip in _chips)
            {
                chipsAppearLogic.AddAnimation(chip.AlphaAnimation);
            }
        }

        public void Appear()
        {
            chipsAppearLogic.Do();
        }
    }
}