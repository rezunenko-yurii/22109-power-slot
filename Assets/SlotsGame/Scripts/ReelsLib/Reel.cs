using System.Collections.Generic;
using Core;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.ReelsLib
{
    public abstract class Reel : AdvancedMonoBehaviour
    {
        [Inject] protected Config _config;
        [Inject] protected DiContainer _container;
        
        protected Transform _transform;
        protected Vector2 _size;

        public Sector mainSector;
        [SerializeField] public ReelAnimController controller;

        public void Init(Vector2 size)
        {
            _transform = GetComponent<Transform>();
            SetSize(size);
            
            Create();
            SetSectorsPositions();
        }
        

        protected abstract void SetSectorsPositions();
        protected abstract void Create();

        protected Vector2 CalculateSectorSize()
        {
            Vector2 sectorSize = Vector2.zero;
            sectorSize.x = _size.x;
            sectorSize.y = _size.y;

            return sectorSize;
        }

        protected void SetSize(Vector2 newSize)
        {
            _size = newSize;
            //_transform.sizeDelta = _size;
        }
        public void SetPositionX(float x)
        {
            _transform.localPosition = new Vector2(x, 0);
        }

        protected Sector CreateSector()
        {
           return _container.InstantiatePrefabForComponent<Sector>(_config.reelsBlueprint.sectorPrefab, _transform);
        }

        public abstract Chip[] GetAllChips();

        public abstract List<SlotAnimController> GetSectorsControllers();

        public abstract Cell[] GetAllCells();
    }
}