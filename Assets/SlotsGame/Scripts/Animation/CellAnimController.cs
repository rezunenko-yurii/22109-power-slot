using System.Collections.Generic;
using SlotsGame.Scripts.CellsLib;
using UnityEngine;

namespace SlotsGame.Scripts.Animation
{
    public class CellAnimController : SlotAnimController
    {
        [SerializeField] private Cell cell;
        
        protected override List<SlotAnimController> GetControllers()
        {
            return new List<SlotAnimController>() {cell.chip.controller};
        }
    }
}