using SlotsGame.Scripts.Slot;
using UnityEngine;

namespace SlotsGame.Scripts.ChipsLib
{
    [CreateAssetMenu(fileName = "FreeSpinsBlueprint", menuName = "Slots/Create FreeSpinsBlueprint")]
    public class FreeSpinsBlueprint : Blueprint
    {
        public override Type SlotType { get; protected set; } = Type.FreeSpins;
    }
}