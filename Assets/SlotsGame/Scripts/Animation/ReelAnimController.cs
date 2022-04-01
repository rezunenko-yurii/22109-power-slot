using System.Collections.Generic;
using SlotsGame.Scripts.ReelsLib;
using UnityEngine;

namespace SlotsGame.Scripts.Animation
{
    public class ReelAnimController : SlotAnimController
    {
        [SerializeField] private Reel reel;
        
        protected override List<SlotAnimController> GetControllers()
        {
            return reel.GetSectorsControllers();
        }
    }
}