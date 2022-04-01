using System.Collections.Generic;
using SlotsGame.Scripts.Slot;
using UnityEngine;

namespace SlotsGame.Scripts.Animation
{
    public class SectorAnimController : SlotAnimController
    {
        [SerializeField] private Sector sector;
        
        protected override List<SlotAnimController> GetControllers()
        {
            return sector.GetCellsControllers();
        }
    }
}