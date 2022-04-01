using System;
using System.Collections.Generic;
using Core.Animations;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.Combinations;
using UnityEngine;
using UnityEngine.UI;
using Type = SlotsGame.Scripts.Slot.Type;

namespace SlotsGame.Scripts.ChipsLib
{
    public class Chip : MonoBehaviour
    {
        private event Action Appeared;
        private event Action Disappeared;
        private event Action Moved;
        
        [SerializeField] private SpriteRenderer image;
        [SerializeField] private Blueprint _blueprint;
        
        [field: SerializeField] public BaseAnimation AlphaAnimation { get; private set; }

        private IAnimation _disappearAnim;
        private ISimpleAnimation _moveAnim;

        public RectTransform rectTransform { get; private set; }

        public ChipBlueprintChanger _changer;

        [SerializeField] public ChipAnimController controller;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void AddToStack(Blueprint blueprint)
        {
            _changer.Add(blueprint);
        }

        public void SetNext()
        {
            _blueprint = _changer.GetBlueprient();
            
            image.sprite = _blueprint.SlotSprite;
            //image.SetNativeSize();
        }

        public void Appear()
        {
            Appeared?.Invoke();
        }
        
        public void Disappear()
        {
            Disappeared?.Invoke();
        }
        
        public void Init()
        {
            _changer = new ChipBlueprintChanger();
            //controller.Init();
        }
    }
    
    [Serializable]
    public abstract class Blueprint : ScriptableObject
    {
        public abstract Type SlotType { get; protected set; }
        public Sprite SlotSprite;
        public bool isAvailable = true;
        public SearchMode SearchMode;
        public int minCombinationAmount = 3;

        [Range(0,10)]
        public int dropCoefficient = 0;
        
        [SerializeReference]
        public List<CombinationReward> Rewards;

        public virtual bool CompareTo(Blueprint other)
        {
            return this == other;
        }
    }

    public enum SearchMode
    {
        Lines,
        Grid
    }
}