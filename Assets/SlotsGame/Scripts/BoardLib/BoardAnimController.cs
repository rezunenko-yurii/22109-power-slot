using System.Collections.Generic;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.ReelsLib;
using Zenject;

namespace SlotsGame.Scripts.BoardLib
{
    public class BoardAnimController : SlotAnimController
    {
        [Inject] private Reels _reels;
        
        protected override List<SlotAnimController> GetControllers()
        {
            return _reels.Controllers();
        }
    }
}