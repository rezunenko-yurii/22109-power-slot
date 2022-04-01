using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.Lines;
using SlotsGame.Scripts.ReelsLib;
using UnityEngine;

namespace SlotsGame.Scripts.Slot
{
    [CreateAssetMenu(fileName = "Slot Config", menuName = "Slots/Create Config")]
    public class Config : ScriptableObject
    {
        public Vector2Int gridSize;
            
        public Blueprints blueprints;
        public ReelsBlueprint reelsBlueprint;
        
        public LinesBlueprints linesBlueprints;
    }
}