using System.Collections.Generic;
using SlotsGame.Scripts.Slot;
using UnityEngine;

namespace SlotsGame.Scripts.ChipsLib
{
    [CreateAssetMenu(fileName = "WildBlueprint", menuName = "Slots/Create WildBlueprint")]
    public class WildBlueprint : Blueprint
    {
        public override Type SlotType { get; protected set; } = Type.Wild;
        public List<Slot.Type> ExceptList;

        public override bool CompareTo(Blueprint other)
        {
            return this == other || !ExceptList.Contains(other.SlotType);
        }
    }
}