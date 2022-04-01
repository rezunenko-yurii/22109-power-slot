using System.Collections.Generic;
using UnityEngine;

namespace SlotsGame.Scripts.ChipsLib
{
    [CreateAssetMenu(fileName = "Slots Blueprints", menuName = "Slots/Create Blueprints")]
    public class Blueprints : ScriptableObject
    {
        /*[Header("List of interfaces")]
        [SerializeReference]
        [SerializeReferenceButton] */
        public List<Blueprint> items;
    }
}