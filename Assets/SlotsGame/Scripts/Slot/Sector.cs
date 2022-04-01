using System.Collections.Generic;
using Core;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.ChipsLib;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.Slot
{
    public class Sector : AdvancedMonoBehaviour
    {
        [Inject] private Config _config;
        [Inject] private DiContainer _container;
        
        private Transform _rectTransform;
        
        public Cell[] cells;
        
        private Vector2 _size;
        [SerializeField] public SectorAnimController controller;

        public void Init(Vector2 size)
        {
            _rectTransform = GetComponent<Transform>();
            SetSize(size);
            
            Create();
            SetCellPositions();
        }
        
        private void SetCellPositions()
        {
            Vector2 cellSize = CalculateCellSize();
            float startPoint = (_size.y / 2) - cellSize.y / 2;
            float step = startPoint;
            
            foreach (var cell in cells)
            {
                cell.SetPositionY(step);
                step -= cellSize.y;
            }
        }

        private void Create()
        {
            Vector2 cellSize = CalculateCellSize();
            cells = new Cell[_config.gridSize.x];

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = _container.InstantiatePrefabForComponent<Cell>(_config.reelsBlueprint.cellPrefab, _rectTransform);
                cells[i].Init(cellSize);
            }
        }

        private Vector2 CalculateCellSize()
        {
            Vector2 cellSize = Vector2.zero;
            cellSize.x = _size.x;
            cellSize.y = _size.y / _config.gridSize.x;

            return cellSize;
        }

        private void SetSize(Vector2 newSize)
        {
            _size = newSize;
            //_rectTransform.sizeDelta = _size;
        }

        public void SetPositionY(float y)
        {
            _rectTransform.localPosition = new Vector2(0, y);
        }
        
        public Chip[] GetAllChips()
        {
            Chip[] allChips = new Chip[cells.Length];

            for (int i = 0; i < cells.Length; i++)
            {
                allChips[i] = cells[i].chip;
            }

            return allChips;
        }

        public List<SlotAnimController> GetCellsControllers()
        {
            List<SlotAnimController> list = new List<SlotAnimController>();

            foreach (var cell in cells)
            {
                list.Add(cell.controller);
            }

            return list;
        }

        public Chip[] GetCells()
        {
            throw new System.NotImplementedException();
        }
    }
}