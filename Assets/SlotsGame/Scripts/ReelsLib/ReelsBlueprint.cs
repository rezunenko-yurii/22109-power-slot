using UnityEngine;

namespace SlotsGame.Scripts.ReelsLib
{
    [CreateAssetMenu(fileName = "Reels Blueprint", menuName = "Slots/Create Reels Blueprints")]
    public class ReelsBlueprint : ScriptableObject
    {
        public GameObject reelPrefab;
        public GameObject sectorPrefab;
        public GameObject cellPrefab;
        public GameObject chipPrefab;
        public GameObject selectorPrefab;
    }
}