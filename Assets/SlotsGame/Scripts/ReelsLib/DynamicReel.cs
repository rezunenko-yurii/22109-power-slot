using System.Collections.Generic;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;

namespace SlotsGame.Scripts.ReelsLib
{
    public class DynamicReel : Reel
    {
        private Sector[] _sectors;

        private Sector _upperFakeSector;
        private Sector _lowerFakeSector;
        
        protected override void SetSectorsPositions()
        {
            float overallHeight = _size.y * 3;
            float halfHeight = overallHeight / 2;
            float startPoint = halfHeight - (_size.y / 2);
            float step = startPoint;
            
            Vector2 sectorSize = CalculateSectorSize();
            
            foreach (var sector in _sectors)
            {
                sector.SetPositionY(step);
                step -= sectorSize.y;
            }
        }

        protected override void Create()
        {
            Vector2 sectorSize = CalculateSectorSize();
            
            _sectors = new Sector[3];
            
            for (int i = 0; i < _sectors.Length; i++)
            {
                _sectors[i] = _container.InstantiatePrefabForComponent<Sector>(_config.reelsBlueprint.sectorPrefab, _transform);
                _sectors[i].Init(sectorSize);
            }

            _upperFakeSector = _sectors[0];
            mainSector = _sectors[1];
            _lowerFakeSector = _sectors[2];
        }

        public override Chip[] GetAllChips()
        {
            int chipsCount = _sectors.Length * mainSector.cells.Length;
            Chip[] allChips = new Chip[chipsCount];

            int counter = 0;
            foreach (var sector in _sectors)
            {
                foreach (var chip in sector.GetAllChips())
                {
                    allChips[counter] = chip;
                }
            }

            return allChips;
        }

        public override List<SlotAnimController> GetSectorsControllers()
        {
            List<SlotAnimController> list = new List<SlotAnimController>();

            foreach (var sector in _sectors)
            {
                list.Add(sector.controller);
            }

            return list;
        }

        public override Cell[] GetAllCells()
        {
            throw new System.NotImplementedException();
        }
    }
}