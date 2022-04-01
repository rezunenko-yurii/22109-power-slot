using System;
using UnityEngine;

namespace SlotsGame.Scripts.Lines
{
    [Serializable]
    [CreateAssetMenu(fileName = "Slot Config", menuName = "Slots/Lines Blueprints")]
    public class LinesBlueprints : ScriptableObject
    {
        public LineBlueprint[] items;
    }
}