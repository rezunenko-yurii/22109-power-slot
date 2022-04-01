using System.Collections.Generic;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.ChipsLib;
using Vector2 = UnityEngine.Vector2;

namespace SlotsGame.Scripts.ReelsLib
{
    public class StaticReel : Reel
    {

        protected override  void SetSectorsPositions()
        {
            mainSector.SetPositionY(0);
        }
        
        protected override void Create()
        {
            Vector2 sectorSize = CalculateSectorSize();
            mainSector = CreateSector();
            mainSector.Init(sectorSize);
        }

        public override Chip[] GetAllChips()
        {
            return mainSector.GetAllChips(); 
        }

        public override List<SlotAnimController> GetSectorsControllers()
        {
            return new List<SlotAnimController>() {mainSector.controller};
        }

        public override Cell[] GetAllCells()
        {
            return mainSector.cells;
        }
    }
}