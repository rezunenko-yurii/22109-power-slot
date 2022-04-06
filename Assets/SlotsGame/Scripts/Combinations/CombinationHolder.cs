using System;
using System.Collections.Generic;
using System.Linq;
using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Lines;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SlotsGame.Scripts.Combinations
{
    public class CombinationHolder
    {
        public Action Changed;
        [Inject] private Config _config;
        public Blueprint[,] grid;
        [Inject] private LinesManager _linesManager;

        private List<WinCombination> _winCombinations = new List<WinCombination>();
        private List<Vector2Int> cells = new List<Vector2Int>();
        public void Init()
        {
            if (_config.blueprints.items.Count == 0)
            {
                throw new Exception("Chips blueprint amount can`t be 0");
            }
            
            grid = new Blueprint[_config.gridSize.x, _config.gridSize.y];
        }
        
        public void Shuffle()
        {
            //Debug.Log("Shuffle");
            string s = "";
            for (int row = 0; row < _config.gridSize.x; row++)
            {
                for (int col = 0; col < _config.gridSize.y; col++)
                {
                    grid[row, col] = GetRandom();
                    s += $" {grid[row, col].SlotSprite.name}";
                }
                //Debug.Log(s);
                s = "";
            }
        }

        public Blueprint GetRandom()
        {
            Blueprint blueprint = null;
            
            do
            {
                int weight = Random.Range(0, 10);
                int num = Random.Range(0, _config.blueprints.items.Count);
                
                if (_config.blueprints.items[num].dropCoefficient <= weight)
                {
                    blueprint = _config.blueprints.items[num];
                }
            } 
            while (blueprint == null || !blueprint.isAvailable);
            
            return blueprint;
        }
        
        public void Find()
        {
            foreach (var item in _config.blueprints.items)
            {
                if (item.SearchMode == SearchMode.Lines)
                {
                    FindInLines(item);
                }
                else if(item.SearchMode == SearchMode.Grid)
                {
                    FindInGrid(item);
                }
                else
                {
                    throw new Exception($"Unknown searchmode {item.SearchMode}");
                }
            }
            
            Changed?.Invoke();
        }

        private void FindInGrid(Blueprint item)
        {
            var winCombination = new WinCombination(){SlotBlueprint = item, Cells = new List<Vector2Int>()};
            
            for (int row = 0; row < _config.gridSize.x; row++)
            {
                for (int col = 0; col < _config.gridSize.y; col++)
                {
                    Blueprint cellBlueprint = grid[row, col];
                    if (cellBlueprint.CompareTo(item))
                    {
                        winCombination.Cells.Add(new Vector2Int(row,col));
                    }
                }
            }
            
            if(winCombination.Cells.Count >= item.minCombinationAmount)
            {
                _winCombinations.Add(winCombination);
                AddWinCellPos(winCombination.Cells);
            }
        }

        private void FindInLines(Blueprint item)
        {
            var lines = _linesManager.GetActiveLines();
            List<WinCombination> matches = new List<WinCombination>();
            //Debug.Log($"-------- Find Item:{item.SlotSprite.name}");
            foreach (var line in lines)
            {
                WinCombination winCombination = null;
                bool isChain = false;
                
                foreach (var pos in line.Blueprint.cells)
                {
                    Blueprint cellBlueprint = grid[pos.x, pos.y];
                    
                    //Debug.Log($"row:{pos.x} col:{pos.y} item:{item.SlotSprite.name} cellItem:{cellBlueprint.SlotSprite.name}");
                    
                    if (cellBlueprint.CompareTo(item))
                    {
                        if (!isChain)
                        {
                            winCombination = new WinCombination(){SlotBlueprint = item, Cells = new List<Vector2Int>()};
                            isChain = true;
                        }
                        
                        //Debug.Log("Found");
                        winCombination.Cells.Add(pos);
                    }
                    else
                    {
                        isChain = false;
                    }
                }

                if (winCombination != null)
                {
                    if(winCombination.Cells.Count >= item.minCombinationAmount)
                    {
                        _winCombinations.Add(winCombination);
                        AddWinCellPos(winCombination.Cells);
                    }
                }
                
                FindBestCombination(matches);
                matches.Clear();
            }
        }
        
        private void FindBestCombination(List<WinCombination> matches)
        {
            if (matches.Count == 0)
            {
                return;
            }

            //TODO compare chain valuability
            
            var max = matches.Max(x => x.Cells.Count);
            if (max != null)
            {
                var winCombination = matches.First(x => x.Cells.Count == max);
                _winCombinations.Add(winCombination);
                AddWinCellPos(winCombination.Cells);
            }
        }
        
        private void AddWinCellPos(List<Vector2Int> positions)
        {
            cells = cells.Concat(positions).ToList();
        }

        public List<Vector2Int> GetWinCellsPositions()
        {
            return cells;
        }

        public List<WinCombination> GetWinCombinations()
        {
            return _winCombinations;
        }

        public void Clear()
        {
            _winCombinations.Clear();
            cells.Clear();
            
            Changed?.Invoke();
        }
    }
}