using SlotsGame.Scripts.Slot;
using UnityEngine;

namespace SlotsGame.Scripts.ChipsLib
{
    [CreateAssetMenu(fileName = "Slots StandardBlueprint", menuName = "Slots/Create StandardBlueprint")]
    public class StandardBlueprint : Blueprint
    {
        public override Type SlotType { get; protected set; } = Type.Standard;
    }
}